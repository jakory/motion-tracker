using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace MotionTracker
{
   public class Simulation
   {
      private CvPoint circleCenter = new CvPoint(0,0);
      private int circleRadius = 50;
      private int simWidth = 640;
      private int simHeight = 480;
      public double actualMovementProportion = 0;
      public double actualMovementProp2 = 0;
      public double actualMovementThisFrame = 0;
      private int maxDistance = 50;
      private int minDistance = 1;
      private int noise = 0;
      private Random rand;
      private int xDirection = 1;
      private int yDirection = 1;
      private IplImage lastFrame;
      //private bool flip = true;
      private bool zero = false;

      /// <summary>
      /// constructor
      /// </summary>
      /// <param name="imgWidth"></param>
      /// <param name="imgHeight"></param>
      /// <param name="radius"></param>
      /// <param name="noise"></param>
      /// <param name="minSpeed"></param>
      /// <param name="maxSpeed"></param>
      public Simulation(int imgWidth, int imgHeight, int radius, 
         int noise, int minSpeed, int maxSpeed)
      {
         this.simWidth = imgWidth;
         this.simHeight = imgHeight;
         this.circleRadius = radius;
         this.noise = noise;
         this.minDistance = minSpeed;
         this.maxDistance = maxSpeed;
         this.rand = new Random();

         // circle starts in center of image
         this.circleCenter = new CvPoint(this.simWidth / 2,
            this.simHeight / 2);
 
         // circle starts in random location in image
         //if (this.circleRadius > this.simWidth - this.circleRadius)
         //   this.circleCenter.X = rand.Next(this.simWidth - this.circleRadius,
         //      this.circleRadius);
         //else
         //   this.circleCenter.X = rand.Next(this.circleRadius,
         //      this.simWidth - this.circleRadius);

         //if (this.circleRadius > this.simHeight - this.circleRadius)
         //   this.circleCenter.Y = rand.Next(this.simHeight - this.circleRadius,
         //      this.circleRadius);
         //else
         //   this.circleCenter.Y = rand.Next(this.circleRadius,
         //      this.simHeight - this.circleRadius);
         
         // init last frame
         this.lastFrame = new IplImage(this.simWidth, this.simHeight,
               BitDepth.U8, 3);
      }

      /// <summary>
      /// add noise
      /// </summary>
      /// <param name="percent"></param>
      private void AddNoise(ref IplImage img)
      {
         // add noise to 0-100% of image

         // according to example opencv code, easiest to access pixels by using
         // pixel offset from start of image
         int size = img.Size.Height * img.Size.Width;
         // amount of noise is number of pixels to change, randomly selected
         // e.g., if 100 pixels total and want 10% noise, change 10 pixels
         int amount = (int) (size * ((double)this.noise / 100));

         // could we fill a matrix with a normal distribution of
         // gray values and take subsequent values from there to
         // use as inserted noise? (instead of uniformly generating
         // random gray values)
         //IplImage noise = new IplImage(this.simWidth, this.simHeight,
         //      BitDepth.U8, 3);
         //Cv.RandArr(Cv.RNG(), noise, DistributionType.Normal, 128, 32);

         // add noise:
         for (int i = 0; i < amount; i++)
         {
            // get random pixel index
            int index = rand.Next(size);
            //int gray = rand.Next(255);
            //CvColor color = new CvColor(gray, gray, gray);
            //img.Set1D(index, color);
            // use black and white noise, not gray:
            img.Set1D(index, (i % 2 == 0 ? CvColor.Black :
               CvColor.White));
         }

      }

      /// <summary>
      /// move object
      /// </summary>
      private void MoveObjectConstantDirection()
      {
         // update circle's location
         // randomly add an amount within the allowed range to the
         // x and y coordiantes of the circle's center
         CvPoint move = new CvPoint((
            rand.Next(this.minDistance, this.maxDistance)),
            (rand.Next(this.minDistance, this.maxDistance)));

         // if the circle is about to go off the screen, reverse direction
         // size of circle is radius*2 + line thickness/2 = 2*radius
         if (this.circleCenter.X + move.X <= this.circleRadius) // left edge
            this.xDirection = 1; // move right
         else if (this.circleCenter.X + move.X + this.circleRadius 
            >= this.simWidth) // right edge
            this.xDirection = -1; // move left

         if (this.circleCenter.Y + move.Y <= this.circleRadius) // top edge
            this.yDirection = 1; // move down
         else if (this.circleCenter.Y + move.Y + this.circleRadius 
            >= this.simHeight) // bottom edge
            this.yDirection = -1; // move up

         // make move
         move.X = this.circleCenter.X + move.X * this.xDirection;
         move.Y = this.circleCenter.Y + move.Y * this.yDirection;

         // update circle center
         this.circleCenter = move;
      }

      /// <summary>
      /// move object
      /// </summary>
      private void MoveObjectConstantDistance()
      {
         // update circle's location
         // have a constant speed (a constant distance to move)
         // randomly select a direction (angle theta) to a point on the circle
         // surrounding the current location at a distance of radius+speed
         int xt = rand.Next(0, 360);
         int yt = rand.Next(0, 360);
         //int xtheta = (int) Math.Cos(xt * Math.PI / 180);
         //int ytheta = (int) Math.Sin(yt * Math.PI / 180);
         CvPoint move = new CvPoint((int)(
            this.maxDistance* Math.Cos(xt * Math.PI / 180)),
            (int)(this.maxDistance* Math.Sin(yt * Math.PI / 180)));
         //CvPoint move = new CvPoint((int)(this.maxDistance * // x
         //   Math.Cos((double)rand.Next(0, 360) * Math.PI / 180)),
         //   (int)(this.maxDistance * // y
         //   Math.Sin((double)rand.Next(0, 360) * Math.PI / 180)));

         // if the circle is about to go off the screen, change direction
         // size of circle from center is radius + line thickness = 1.5*radius
         //
         // first, try reversing direction completely
         // if that doesn't work, randomly add to the angle and move around
         // the circle of possible moves until one is found
         //
         // if at the left edge or the right edge, change x
         while ((this.circleCenter.X + move.X < this.circleRadius/2) // left // ** /2 square
            || (this.circleCenter.X + move.X
              + this.circleRadius/2 > this.simWidth)) // right // ** /2 square
         {
            //if (this.flip)
            //{
            //   move.X = -move.X; // move opposite direction
            //   this.flip = false;
            //}
            //else
            //{
               // change angle somewhat
               move.X = (int)(this.maxDistance *
                  Math.Cos(xt + rand.Next(-120, 120) * Math.PI / 180));
            //}
         }

         // if at top or bottom edge, change y
         while ((this.circleCenter.Y + move.Y < this.circleRadius/2) // top ** /2 square
            || (this.circleCenter.Y + move.Y
                + this.circleRadius/2 > this.simHeight)) // bottom // ** /2 square
         {
            //if (!this.flip)
            //{
            //   move.Y = -move.Y; // move other way
            //   this.flip = true;
            //}
            //else
            //{
               move.Y = (int)(this.maxDistance *
                  Math.Sin(yt + rand.Next(-120, 120) * Math.PI / 180));
            //}
         }

         // make move
         this.circleCenter.X = this.circleCenter.X + move.X;
         this.circleCenter.Y = this.circleCenter.Y + move.Y;

         zero = (move.X == 0 && move.Y == 0);
      }

      /// <summary>
      /// calculate displacement
      /// </summary>
      /// <param name="point1"></param>
      /// <param name="radius1"></param>
      /// <param name="point2"></param>
      /// <param name="radius2"></param>
      /// <returns></returns>
      private double CalculateDisplacement(IplImage old, IplImage overlay)
      {
         // old frame and overlay frame both without noise
         // count black pixels in old frame
         // count pixels in overlay frame
         int oldArea, overlayArea, total;
         GetArea(old, out oldArea, out total);
         GetArea(overlay, out overlayArea, out total);

         // subtract old pixels from overlay to get amount displacement
         // calculate (total number of pixels moved / total number of pixels)
         return (double)(overlayArea - oldArea) / (double)total; // was ()/oldArea
      }

      /// <summary>
      /// get area of black pixels in image
      /// </summary>
      /// <param name="img"></param>
      /// <returns></returns>
      private void GetArea(IplImage img, out int area, out int total)
      {
         // marshal the images into byte arrays
         byte[] rawData = new byte[img.ImageSize]; //imageSize uses byte alignment
         System.Runtime.InteropServices.Marshal.Copy(
             img.ImageData, rawData, 0, img.ImageSize);

         area = 0;
         total = rawData.Length;
         foreach (int x in rawData)
            if (x == 0) area += 1; // circle is black; background is white
      }


      /// <summary>
      /// next frame
      /// </summary>
      /// <returns></returns>
      public IplImage NextFrame()
      {
         // don't need a delay
         //System.Threading.Thread.Sleep(30);

         // create image
         IplImage img = new IplImage(this.simWidth, this.simHeight, 
            BitDepth.U8, 3);

         img.Set(CvColor.White);
         
         // update object (circle) location
         //MoveObjectConstantDirection(); // bouncing ball
         MoveObjectConstantDistance(); // move any direction

         // draw circle
         // (set line thickness as negative to get filled circle)
         //*img.Circle(this.circleCenter, this.circleRadius, CvColor.Black, -1);

         // square
         //** also in motiontracker where radius is calculated
         img.Rectangle(new CvPoint(this.circleCenter.X - (this.circleRadius/2),
            this.circleCenter.Y - (this.circleRadius/2)),
            new CvPoint(this.circleCenter.X + (this.circleRadius/2),
            this.circleCenter.Y + (this.circleRadius/2)), CvColor.Black, -1);

         if (this.lastFrame == null) // first frame
         {
            this.lastFrame = Cv.CloneImage(img);
            this.actualMovementProportion = 0;
         }
         else
         {
            // create overlay image for updating actual movement
            // (put the new circle over the previous circle)
            //IplImage overlay = new IplImage(this.simWidth, this.simHeight,
            //   BitDepth.U8, 3);
            //overlay = Cv.CloneImage(this.lastFrame);
           //**overlay.Circle(this.circleCenter, this.circleRadius, CvColor.Black, -1);
            // square
            //overlay.Rectangle(new CvPoint(this.circleCenter.X - (this.circleRadius),
               //this.circleCenter.Y - (this.circleRadius)),
               //new CvPoint(this.circleCenter.X + (this.circleRadius),
               //this.circleCenter.Y + (this.circleRadius)), CvColor.Black, -1);
            
            // update actual movement with change from previous to new location
            //this.actualMovementProportion = CalculateDisplacement(this.lastFrame, overlay);
            //overlay.Dispose();

            // proportion 2
            IplImage diff = new IplImage(this.simWidth, this.simHeight,
               BitDepth.U8, 3);
            Cv.AbsDiff(this.lastFrame, img, diff);
            int area, total;
            GetArea(diff, out area, out total);
            this.actualMovementProp2 = (double)(total - area) / (double)total;
            diff.Dispose();

            // update last frame
            this.lastFrame = Cv.CloneImage(img);
         }

         // movement this frame
         this.actualMovementThisFrame = (zero ? 0 :
            (circleRadius * circleRadius) / (this.simHeight*this.simWidth)); // ** square (side = circleRadius)
           //*Math.PI * //** circle
           //*(circleRadius * circleRadius)
           //* / (this.simHeight*this.simWidth));

         // add noise to image
         AddNoise(ref img);

         return img;
      }

   }
}
