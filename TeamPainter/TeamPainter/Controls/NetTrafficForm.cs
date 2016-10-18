using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
using GraphCounter;

namespace TeamPainter
{
    public partial class NetTrafficForm : Form
    {
        private GraphTrafficData _inTrafficData;
        private GraphTrafficData _outTrafficData;

        public NetTrafficForm()
        {
            InitializeComponent();

            graphIN.LabelColor = graphOut.LabelColor = Color.WhiteSmoke;
            graphIN.GridColorMajor = graphOut.GridColorMajor = Color.WhiteSmoke;
            graphIN.BorderColor = graphOut.BorderColor = Color.WhiteSmoke;
            graphIN.PaddingTextLabelY = graphOut.PaddingTextLabelY = 50;
            graphIN.MinorLineHeight = graphOut.MinorLineHeight = 200;
            graphIN.GraphType = graphOut.GraphType = GraphPlotter.GraphPresent.Curve;

            _inTrafficData = new GraphTrafficData();
            _inTrafficData.GraphColor = Color.Blue;

            _outTrafficData = new GraphTrafficData();
            _outTrafficData.GraphColor = Color.Red;
        }

        public void OnTrafficChangeHandler(object sender, EventArgs arg)
        {
            TrafficCounter tr = sender as TrafficCounter;
            UpdateTrafficInfo(tr);
            UpdateGraph(tr);
        }

        private void NetTrafficForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _inTrafficData.Clear();
            _outTrafficData.Clear();

            this.Hide();
            e.Cancel = true;
        }

        protected void UpdateTrafficInfo(TrafficCounter traffic)
        {
            if (traffic == null) return;

            lblInBytes.Invoke((MethodInvoker)delegate 
            {
                lblInBytes.Text = traffic.TotalInTraffic.ToString() + " bytes";
            });
            lblInPacket.Invoke((MethodInvoker)delegate
            {
                lblInPacket.Text = traffic.TotalInPackets.ToString();
            });
            lblOutBytes.Invoke((MethodInvoker)delegate
            {
                lblOutBytes.Text = traffic.TotalOutTraffic.ToString() + " bytes";
            });
            lblOutPacket.Invoke((MethodInvoker)delegate
            {
                lblOutPacket.Text = traffic.TotalOutPackets.ToString();
            });
        }

        protected void UpdateGraph(TrafficCounter traffic)
        {
            if (traffic == null) return;

            #region INTRAF

            List<TrafficStat> inTraf = new List<TrafficStat>();
            foreach(List<TrafficStat> tr in traffic.INStorage)
            {
                if (tr != null)
                {
                    double time = 0;
                    long bytes = 0;
                    for (int i = 0; i < tr.Count; i++)
                    {
                        bytes += tr[i].PacketLenght;
                        if (i == tr.Count - 1) { time = tr[i].Time; }
                    }
                    TrafficStat tStat = new TrafficStat(time, bytes);
                    inTraf.Add(tStat);
                }
            }

            _inTrafficData.SetTrafficData(inTraf.ToArray());
            graphIN.UpdateGraphData(_inTrafficData);

            #endregion INTRAF

            #region OUTTRAF

            List<TrafficStat> outTraf = new List<TrafficStat>();
            foreach (List<TrafficStat> tr in traffic.OUTStorage)
            {
                if (tr != null)
                {
                    double time = 0;
                    long bytes = 0;
                    for (int i = 0; i < tr.Count; i++)
                    {
                        bytes += tr[i].PacketLenght;
                        if (i == tr.Count - 1) { time = tr[i].Time; }
                    }
                    TrafficStat tStat = new TrafficStat(time, bytes);
                    outTraf.Add(tStat);
                }
            }

            _outTrafficData.SetTrafficData(outTraf.ToArray());
            graphOut.UpdateGraphData(_outTrafficData);

            #endregion OUTTRAF
        }

        public class GraphTrafficData : GraphData
        {
            public void SetTrafficData(TrafficStat[] trafficData)
            {
                if (trafficData == null) return;
                _relativesPoint = new PointF[trafficData.Length];

                double minValue = 0;
                double maxValue = 32;
                for (int i = 0; i < trafficData.Length; i++)
                {
                    if (trafficData[i].PacketLenght > maxValue) { maxValue = trafficData[i].PacketLenght; }
                    if (trafficData[i].PacketLenght < minValue) { minValue = trafficData[i].PacketLenght; }
                }

                double coef = GetTrafficCoefficient(maxValue - minValue);
                double maxLineValue = Math.Ceiling((double)maxValue / coef) * coef;
                double minLinevalue = Math.Floor((double)minValue / coef) * coef;

                double dValue = maxLineValue - minLinevalue;
                for (int i = 0; i < trafficData.Length; i++)
                {
                    double val = maxLineValue - trafficData[i].PacketLenght;
                    _relativesPoint[i].Y = (float)(val / dValue);
                }

                CalcLinesX(minLinevalue, maxLineValue, coef);
            }

            protected void CalcLinesX(double minValue, double maxValue, double coef)
            {
                List<LineData> lines = new List<LineData>();
                List<LineData> linesMinor = new List<LineData>();

                double dValue = maxValue - minValue;
                int posLines = (int)(maxValue / coef);
                int negLines = (int)(minValue / coef);

                for (int i = negLines; i < posLines; i++)
                {
                    LineData line = new LineData();
                    line.Text = GetTrafficString(i * coef);

                    float py = (float)((maxValue - i * coef));
                    line.RelativePoint.Y = (float)(py / dValue);
                    lines.Add(line);

                    double divVal = coef / 8;
                    for (int minor = 1; minor < 8; minor++)
                    {
                        double mLineValue = i * coef + minor * divVal;
                        line = new LineData();
                        line.Text = GetTrafficString(mLineValue);
                        line.RelativePoint.Y = (float)((maxValue - mLineValue) / dValue);
                        linesMinor.Add(line);
                    }
                }
                _linesMajorX = lines.ToArray();
                _linesMinorX = linesMinor.ToArray();
            }


            private double GetTrafficCoefficient(double value)
            {
                double absValue = Math.Abs(value);
                if (absValue < 1) return 1;

                double coef = 1;

                for (double i = 1; i < int.MaxValue; i *= 2)
                {
                    if (absValue >= i) { coef = i; }
                    else { break; }
                }
                return coef;
            }

            private string GetTrafficString(double value)
            {
                double absValue = Math.Abs(value);
                if (absValue < 1024) { return value.ToString() + " b"; }
                else if (absValue < 1048576) { return (value / 1024).ToString() + " Kb"; }
                else { return (value / 1048576).ToString() + " Mb"; }
            }
        }
    }
}
