/**
 *   MOTION TRACKER: Video-based software for tracking motion over time.
 *   Copyright (C) 2012. Jacqueline Kory. Sidney D'Mello. Andrew Olney.
 *   Contact: jacqueline.kory@gmail.com
 *   
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionTracker
{
   public partial class InternalParametersForm : Form
   {
      private bool okflag = false; // ok flag
      public double MHIDuration = 0;
      public int BinaryThreshold = 0;
      public double haarScaleFactor = 0;
      public int haarMinNeighbors = 0;
      public int haarMinWidth = 0;
      public int haarMinHeight = 0;
      public string haarXMLFile = "";

      private List<string> xmlFiles = new List<string>();
      private List<string> xmlFullPaths = new List<string>();

      /// <summary>
      /// constructor
      /// </summary>
      public InternalParametersForm()
      {
         InitializeComponent();
      }

      /// <summary>
      /// on form load event andler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void InternalParametersForm_Load(object sender, EventArgs e)
      {
         // set default values
         this._binaryThreshUpDown.Value = Constants.DEFAULT_BINARY_THRESHOLD;
         this._mhiDurationUpDown.Value = (decimal)Constants.DEFAULT_MHI_DURATION;
         this._haarScaleUpDown.Value = (decimal)Constants.DEFAULT_HAAR_SCALE_FACTOR;
         this._haarMinNeighborsUpDown.Value = Constants.DEFAULT_HAAR_MIN_NEIGHBORS;
         this._haarMinHeightUpDown.Value = Constants.DEFAULT_HAAR_MIN_HEIGHT;
         this._haarMinWidthUpDown.Value = Constants.DEFAULT_HAAR_MIN_WIDTH;

         // get list of available haar cascade xml files and put in combo box
         // (get from local Debug folder)
         try
         {
            this.xmlFullPaths = System.IO.Directory.GetFiles(
               System.IO.Directory.GetCurrentDirectory(), "*.xml").ToList<string>();

            foreach (string f in this.xmlFullPaths)
               this.xmlFiles.Add(System.IO.Path.GetFileName(f));

            this._haarXMLFileComboBox.DataSource = this.xmlFiles;
         }
         catch
         {
            this._haarXMLFileComboBox.DataSource = 
               Constants.DEFAULT_HAAR_XML_FILE;
         }
             

         this.FormClosed += new FormClosedEventHandler(InternalParametersForm_FormClosed);
      }

      /// <summary>
      /// on form closed event handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void InternalParametersForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         try
         {
            if (this.okflag)
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }
      }

      /// <summary>
      /// cancel button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _cancelButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      /// <summary>
      /// ok button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _okButton_Click(object sender, EventArgs e)
      {
         // set OK flag
         this.okflag = true;

         // save values
         this.MHIDuration = (double)this._mhiDurationUpDown.Value;
         this.BinaryThreshold = (int)this._binaryThreshUpDown.Value;
         this.haarScaleFactor = (double)this._haarScaleUpDown.Value;
         this.haarMinNeighbors = (int)this._haarMinNeighborsUpDown.Value;
         this.haarMinWidth = (int)this._haarMinWidthUpDown.Value;
         this.haarMinHeight = (int)this._haarMinHeightUpDown.Value;
         this.haarXMLFile = this.xmlFullPaths[this._haarXMLFileComboBox.SelectedIndex];

         // and close form
         this.Close();
      }

   }
}
