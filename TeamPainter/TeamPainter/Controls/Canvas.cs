/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 11.07.2016 16:18:16
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Nano3;
using Nano3.Collection;

namespace TeamPainter
{
    public class Canvas : Control
    {
        public event EventHandler CanvasClearEvent;

        private bool _isCleared;
        public bool IsCleared { get { return _isCleared; } }

        private object _canvasSync = new object();
        private bool _needUpdateFrontPicture;

        private PictureBoxObj _backPicture;
        public PictureBoxObj BackPicture { get { return _backPicture; } }
        private PictureBoxObj _frontPicture;
        public PictureBoxObj FrontPicture { get { return _frontPicture; } }

        private FastDictionaryM2<long, PictureBoxObj> _drawObjects = new FastDictionaryM2<long, PictureBoxObj>();
        private FastQueueHashM2<long> _toApplyPB = new FastQueueHashM2<long>();
        private FastQueueHashM2<long> _toRemovePB = new FastQueueHashM2<long>();
        private FastDictionaryM2<long, DrawObjectList> _editPBDrawObjects = new FastDictionaryM2<long, DrawObjectList>();

        public Canvas()
        {
            _isCleared = true;
            //для уменьшения мерцания
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw | ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        }

        public void SetCanvas(PictureBoxObj pb)
        {
            lock (_canvasSync)
            {
                if (pb == null || pb.Image == null) return;

                Width = pb.Width;
                Height = pb.Height;

                _backPicture = pb;
                this.Controls.Add(_backPicture);
                _backPicture.SendToBack();
                _backPicture.Invalidate();

                
                _frontPicture = new PictureBoxObj(_backPicture.ClientID, _backPicture.UniqueID, PictureBoxStatus.Canvas);
                this.Controls.Add(_frontPicture);

                _frontPicture.Width = pb.Width;
                _frontPicture.Height = pb.Width;
                _frontPicture.Image = new Bitmap(Width, Height);
                _frontPicture.BringToFront();            

                _editPBDrawObjects[0] = new DrawObjectList(0);
            }

            _isCleared = false;
            _needUpdateFrontPicture = true;
            AppLogger.Log("Picture loaded: width " + Width + ", height " + Height);
        }
        public Image GetBackPicture()
        {
            lock (_canvasSync)
            {
                if (_backPicture != null && _backPicture.Image != null)
                {
                    return new Bitmap(_backPicture.Image);
                }
                else return null;
            }
        }

        public PictureBoxObj GetEditablePictureBox(long controlID)
        {
            lock (_canvasSync)
            {
                PictureBoxObj c; _drawObjects.TryGetValue(controlID, out c);
                return c;
            }
        }
        public PictureBoxObj[] GetAllPictureBoxes()
        {
            lock (_canvasSync) { return _drawObjects.GetValues(); }
        }

        public void AddPictureObj(PictureBoxObj pic, Point location)
        {
            if (IsCleared || pic == null) { return; }
            lock (_canvasSync)
            {
                if (_drawObjects.ContainsKey(pic.UniqueID)) return;

                _backPicture.Controls.Add(pic);
                pic.Location = location;
                _drawObjects.Add(pic.UniqueID, pic);
                _editPBDrawObjects.Add(pic.UniqueID, new DrawObjectList(pic.UniqueID));

                pic.Invalidate();
            }
            AppLogger.Log("Created new pictureBox, location: " + location + " size: " + pic.Size);
        }
        public void AddDrawObject(long picID, DrawObject drawObj)
        {
            if (IsCleared || drawObj == null) return;
            lock (_canvasSync)
            {
                DrawObjectList drl;
                _editPBDrawObjects.TryGetValue(picID, out drl);
                if (drl != null) { drl.AddDrawObject(drawObj); }
            }
        }
        public void DrawPictureBoxesByDrawObjects()
        {
            DrawObjectList[] drls = null;
            lock (_canvasSync)
            {
                drls = _editPBDrawObjects.GetValues();
                if (drls == null) return;
                for (int i = 0; i < drls.Length; i++)
                {
                    List<DrawObject> dl = drls[i].GetAllDrawObjects();
                    for (int l = 0; l < dl.Count; l++)
                    {
                        if (ToolDrawer.Draw(dl[l])) { _needUpdateFrontPicture = true; }
                    }
                }
            }
        }

        public void AddRemovePBIndex(long picID)
        {
            if (IsCleared) { return; }
            lock (_canvasSync) { _toRemovePB.Enqueue(picID); }
        }
        public void RemovePictureObj(long picID)
        {
            lock (_canvasSync)
            {
                PictureBoxObj pic;
                _drawObjects.TryGetValue(picID, out pic);
                _drawObjects.Remove(picID);
                if (pic == null) return;

                _backPicture.Controls.Remove(pic);
                pic.Dispose();
                RemoveDrawObjectList(picID);
                _needUpdateFrontPicture = true;
            }
        }
        public void RemoveAllNeededPictureObjects()
        {
            lock (_canvasSync)
            {
                long[] pbIDs = _toRemovePB.DequeueAll();
                if (pbIDs == null) return;
                for (int i = 0; i < pbIDs.Length; i++)
                {
                    RemovePictureObj(pbIDs[i]);
                }
            }
        }

        public void AddAppliedPBIndex(long picID)
        {
            if (IsCleared) return;
            lock (_canvasSync) { _toApplyPB.Enqueue(picID); }
        }
        public void ApplyPictureObj(long picID)
        {
            lock (_canvasSync)
            {
                PictureBoxObj pic;
                _drawObjects.TryGetValue(picID, out pic);
                if (pic == null || pic.Image == null) return;
                Bitmap bm = new Bitmap(pic.Image);

                using (Graphics gr = Graphics.FromImage(_backPicture.Image)){
                   gr.DrawImage(bm, pic.Location);
                }
                _drawObjects.Remove(picID);

                _backPicture.Controls.Remove(pic);
                pic.Dispose();
                RemoveDrawObjectList(picID);
                _backPicture.Invalidate();
                _needUpdateFrontPicture = true;
            }
        }
        public void ApplyAllNeededPictureObjects()
        {
            lock (_canvasSync)
            {
                long[] pbIDs = _toApplyPB.DequeueAll();
                if (pbIDs == null) return;
                for (int i = 0; i < pbIDs.Length; i++)
                {
                    ApplyPictureObj(pbIDs[i]);
                }
            }
        }

        private void RemoveDrawObjectList(long picObjID)
        {
            DrawObjectList drl = null;
            lock (_canvasSync)
            {
                _editPBDrawObjects.TryGetValue(picObjID, out drl);
                _editPBDrawObjects.Remove(picObjID);
            }
            if (drl != null) { drl.Clear(); }
        }

        public void PictureInvalidate()
        {
            if (_backPicture == null) return;
            lock (_canvasSync){ _backPicture.Invalidate(); }
        }
        public void UpdateCanvas()
        {
            if (!_needUpdateFrontPicture || IsCleared) return;
            lock (_canvasSync)
            {
                using (Graphics gr = Graphics.FromImage(_frontPicture.Image))
                {
                    gr.DrawImage(_backPicture.Image, new Rectangle(0, 0, _frontPicture.Width, _frontPicture.Height),
                            new Rectangle(0, 0, _backPicture.Width, _backPicture.Height), GraphicsUnit.Pixel);
                    PictureBoxObj[] pbs = _drawObjects.GetValues();
                    if (pbs != null)
                    {
                        for (int i = 0; i < pbs.Length; i++)
                        {
                            if (pbs[i] == null || pbs[i].Image == null) continue;
                            Rectangle rectFrom = new Rectangle(0, 0, pbs[i].Width, pbs[i].Height);
                            Rectangle rectTo = new Rectangle(pbs[i].Location.X, pbs[i].Location.Y, pbs[i].Width, pbs[i].Height);
                            gr.DrawImage(pbs[i].Image, rectTo, rectFrom, GraphicsUnit.Pixel);
                        }
                    }
                }
                _frontPicture.Invalidate();
                _needUpdateFrontPicture = false;
            }
        }

        public void ClearRect(Rectangle rect)
        {
            if (_isCleared) return;

            lock (_canvasSync)
            {
                using (Graphics gr = Graphics.FromImage(_backPicture.Image)){
                    gr.FillRectangle(new SolidBrush(Color.White), rect);
                }
                _backPicture.Invalidate();
                _needUpdateFrontPicture = true;
            }
        }
        public void Clear()
        {
            if (_isCleared) return;
            _isCleared = true;
            _needUpdateFrontPicture = true;

            _toRemovePB.Clear();
            _toApplyPB.Clear();

            PictureBoxObj[] pbs = _drawObjects.GetValues();
            for (int i = 0; i < pbs.Length; i++){
                RemovePictureObj(pbs[i].UniqueID);
            }
            _drawObjects.Clear();
            this.Controls.Remove(_backPicture);
            this.Controls.Remove(_frontPicture);

            CanvasClearEvent?.Invoke(this, null);

            _backPicture.Dispose();
            _frontPicture.Dispose();
        }
    }
}
