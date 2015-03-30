using System;
namespace WEKAConversion
{
	class FacialExpressionMotionBooster
	{
	
		private static double RtoP(double[] R, int j)
		{
			double Rcenter = 0;
			for (int i = 0; i < R.Length; i++)
			{
				Rcenter += R[i];
			}
			Rcenter /= R.Length;
			double Rsum = 0;
			for (int i = 0; i < R.Length; i++)
			{
				Rsum += System.Math.Exp(R[i] - Rcenter);
			}
			return System.Math.Exp(R[j]) / Rsum;
		}
	
		public static double classify(System.Object[] i)
		{
			double[] d = distribution(i);
			double maxV = d[0];
			int maxI = 0;
			for (int j = 1; j < 6; j++)
			{
				if (d[j] > maxV)
				{
					maxV = d[j]; maxI = j;
				}
			}
			return (double) maxI;
		}
	
		public static double[] distribution(System.Object[] i)
		{
			double[] Fs = new double[6];
			double[] Fi = new double[6];
			double Fsum;
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_0.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_0.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_0.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_0.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_0.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_0.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_1.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_1.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_1.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_1.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_1.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_1.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_2.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_2.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_2.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_2.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_2.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_2.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_3.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_3.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_3.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_3.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_3.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_3.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_4.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_4.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_4.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_4.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_4.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_4.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_5.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_5.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_5.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_5.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_5.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_5.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_6.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_6.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_6.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_6.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_6.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_6.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_7.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_7.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_7.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_7.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_7.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_7.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_8.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_8.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_8.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_8.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_8.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_8.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_9.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_9.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_9.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_9.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_9.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_9.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_10.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_10.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_10.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_10.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_10.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_10.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_11.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_11.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_11.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_11.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_11.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_11.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_12.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_12.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_12.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_12.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_12.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_12.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_13.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_13.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_13.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_13.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_13.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_13.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_14.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_14.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_14.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_14.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_14.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_14.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_15.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_15.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_15.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_15.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_15.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_15.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_16.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_16.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_16.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_16.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_16.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_16.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_17.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_17.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_17.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_17.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_17.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_17.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_18.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_18.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_18.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_18.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_18.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_18.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_19.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_19.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_19.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_19.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_19.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_19.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_20.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_20.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_20.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_20.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_20.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_20.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_21.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_21.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_21.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_21.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_21.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_21.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_22.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_22.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_22.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_22.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_22.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_22.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_23.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_23.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_23.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_23.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_23.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_23.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_24.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_24.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_24.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_24.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_24.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_24.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_25.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_25.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_25.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_25.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_25.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_25.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_26.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_26.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_26.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_26.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_26.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_26.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_27.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_27.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_27.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_27.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_27.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_27.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_28.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_28.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_28.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_28.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_28.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_28.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			Fsum = 0;
			Fi[0] = FacialExpressionMotionBooster_0_29.classify(i); Fsum += Fi[0];
			Fi[1] = FacialExpressionMotionBooster_1_29.classify(i); Fsum += Fi[1];
			Fi[2] = FacialExpressionMotionBooster_2_29.classify(i); Fsum += Fi[2];
			Fi[3] = FacialExpressionMotionBooster_3_29.classify(i); Fsum += Fi[3];
			Fi[4] = FacialExpressionMotionBooster_4_29.classify(i); Fsum += Fi[4];
			Fi[5] = FacialExpressionMotionBooster_5_29.classify(i); Fsum += Fi[5];
			Fsum /= 6;
			for (int j = 0; j < 6; j++)
			{
				Fs[j] += (Fi[j] - Fsum) * 5 / 6;
			}
			double[] dist = new double[6];
			for (int j = 0; j < 6; j++)
			{
				dist[j] = RtoP(Fs, j);
			}
			return dist;
		}
	}
	class FacialExpressionMotionBooster_0_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return - 0.2805151175812238;
			}
			else if (((System.Double) i[30]) <= 2.5)
			{
				return - 0.8138453217955726;
			}
			else
			{
				return 0.2918165989552464;
			}
		}
	}
	class FacialExpressionMotionBooster_0_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_80 */
			if (i[80] == null)
			{
				return - 0.05111956519426895;
			}
			else if (((System.Double) i[80]) <= 7.5)
			{
				return - 0.4119734415862289;
			}
			else
			{
				return 0.4615654242039052;
			}
		}
	}
	class FacialExpressionMotionBooster_0_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_26 */
			if (i[26] == null)
			{
				return - 0.03733406525358556;
			}
			else if (((System.Double) i[26]) <= 11.5)
			{
				return 0.1005353956750432;
			}
			else
			{
				return - 0.7240598911476749;
			}
		}
	}
	class FacialExpressionMotionBooster_0_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_98 */
			if (i[98] == null)
			{
				return 0.0490883537838937;
			}
			else if (((System.Double) i[98]) <= 1.5)
			{
				return - 0.2991855973289927;
			}
			else
			{
				return 0.4848168510949884;
			}
		}
	}
	class FacialExpressionMotionBooster_0_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_44 */
			if (i[44] == null)
			{
				return - 0.02154235754674956;
			}
			else if (((System.Double) i[44]) <= 10.5)
			{
				return 0.1355207192634434;
			}
			else
			{
				return - 0.6041304682417274;
			}
		}
	}
	class FacialExpressionMotionBooster_0_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_91 */
			if (i[91] == null)
			{
				return 0.02075864612977513;
			}
			else if (((System.Double) i[91]) <= 1.5)
			{
				return - 0.2804107027925184;
			}
			else
			{
				return 0.4945994351934357;
			}
		}
	}
	class FacialExpressionMotionBooster_0_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_38 */
			if (i[38] == null)
			{
				return 0.002109177020987043;
			}
			else if (((System.Double) i[38]) <= 8.5)
			{
				return 0.1636686347135498;
			}
			else
			{
				return - 0.3118217810541108;
			}
		}
	}
	class FacialExpressionMotionBooster_0_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_38 */
			if (i[38] == null)
			{
				return 0.0220873010503292;
			}
			else if (((System.Double) i[38]) <= 1.5)
			{
				return - 0.4762122140722939;
			}
			else
			{
				return 0.2126009300736074;
			}
		}
	}
	class FacialExpressionMotionBooster_0_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_82 */
			if (i[82] == null)
			{
				return - 0.03131213297392277;
			}
			else if (((System.Double) i[82]) <= 16.5)
			{
				return - 0.09745813674026062;
			}
			else
			{
				return 0.6698077514494339;
			}
		}
	}
	class FacialExpressionMotionBooster_0_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_53 */
			if (i[53] == null)
			{
				return 0.03395697952209065;
			}
			else if (((System.Double) i[53]) <= 13.5)
			{
				return 0.1295068408451869;
			}
			else
			{
				return - 0.4957536463204234;
			}
		}
	}
	class FacialExpressionMotionBooster_0_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_84 */
			if (i[84] == null)
			{
				return 0.00359131118028538;
			}
			else if (((System.Double) i[84]) <= 9.5)
			{
				return - 0.1195824949389704;
			}
			else
			{
				return 0.4072960256929871;
			}
		}
	}
	class FacialExpressionMotionBooster_0_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_47 */
			if (i[47] == null)
			{
				return - 0.02074088980302669;
			}
			else if (((System.Double) i[47]) <= 5.5)
			{
				return 0.1837769669349102;
			}
			else
			{
				return - 0.211805323418207;
			}
		}
	}
	class FacialExpressionMotionBooster_0_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_34 */
			if (i[34] == null)
			{
				return 0.01491503953688204;
			}
			else if (((System.Double) i[34]) <= 1.5)
			{
				return - 0.2750678896372614;
			}
			else
			{
				return 0.1757490584487964;
			}
		}
	}
	class FacialExpressionMotionBooster_0_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_75 */
			if (i[75] == null)
			{
				return - 0.01278269272644675;
			}
			else if (((System.Double) i[75]) <= 2.5)
			{
				return 0.2051326344837844;
			}
			else
			{
				return - 0.1969750797007593;
			}
		}
	}
	class FacialExpressionMotionBooster_0_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_81 */
			if (i[81] == null)
			{
				return 0.00839116467024645;
			}
			else if (((System.Double) i[81]) <= 2.5)
			{
				return - 0.1217593012424194;
			}
			else
			{
				return 0.2756936964177234;
			}
		}
	}
	class FacialExpressionMotionBooster_0_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_51 */
			if (i[51] == null)
			{
				return - 0.005954859538983153;
			}
			else if (((System.Double) i[51]) <= 15.5)
			{
				return 0.05900087200452809;
			}
			else
			{
				return - 0.5640338828668523;
			}
		}
	}
	class FacialExpressionMotionBooster_0_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_3 */
			if (i[3] == null)
			{
				return 0.006187047231951566;
			}
			else if (((System.Double) i[3]) <= 8.5)
			{
				return - 0.03012875131222749;
			}
			else
			{
				return 1.006968785410905;
			}
		}
	}
	class FacialExpressionMotionBooster_0_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_96 */
			if (i[96] == null)
			{
				return - 0.007445343229909705;
			}
			else if (((System.Double) i[96]) <= 17.5)
			{
				return 0.03281861245571037;
			}
			else
			{
				return - 0.7688780421470241;
			}
		}
	}
	class FacialExpressionMotionBooster_0_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_78 */
			if (i[78] == null)
			{
				return 0.009185207411230984;
			}
			else if (((System.Double) i[78]) <= 9.5)
			{
				return - 0.1275287625019483;
			}
			else
			{
				return 0.1994833630576642;
			}
		}
	}
	class FacialExpressionMotionBooster_0_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_57 */
			if (i[57] == null)
			{
				return - 0.0283659992904919;
			}
			else if (((System.Double) i[57]) <= 5.5)
			{
				return 0.2017376219080359;
			}
			else
			{
				return - 0.2163878526551258;
			}
		}
	}
	class FacialExpressionMotionBooster_0_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_21 */
			if (i[21] == null)
			{
				return 0.01373389326874289;
			}
			else if (((System.Double) i[21]) <= 1.5)
			{
				return - 0.1485058645774589;
			}
			else
			{
				return 0.1928694596425391;
			}
		}
	}
	class FacialExpressionMotionBooster_0_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_38 */
			if (i[38] == null)
			{
				return - 0.01942949095257332;
			}
			else if (((System.Double) i[38]) <= 8.5)
			{
				return 0.1021392454411417;
			}
			else
			{
				return - 0.2832967241457881;
			}
		}
	}
	class FacialExpressionMotionBooster_0_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_81 */
			if (i[81] == null)
			{
				return 0.00603391349332233;
			}
			else if (((System.Double) i[81]) <= 5.5)
			{
				return - 0.06135894383899722;
			}
			else
			{
				return 0.4075148675957698;
			}
		}
	}
	class FacialExpressionMotionBooster_0_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return - 0.004748753988491361;
			}
			else if (((System.Double) i[74]) <= 10.5)
			{
				return 0.1018099097334951;
			}
			else
			{
				return - 0.2819068840818272;
			}
		}
	}
	class FacialExpressionMotionBooster_0_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_60 */
			if (i[60] == null)
			{
				return 0.01825782353041153;
			}
			else if (((System.Double) i[60]) <= 1.5)
			{
				return - 0.1706714043536193;
			}
			else
			{
				return 0.1765475889074468;
			}
		}
	}
	class FacialExpressionMotionBooster_0_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_36 */
			if (i[36] == null)
			{
				return - 0.004475177314635473;
			}
			else if (((System.Double) i[36]) <= 7.5)
			{
				return 0.09813151716543594;
			}
			else
			{
				return - 0.2167581286153446;
			}
		}
	}
	class FacialExpressionMotionBooster_0_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_84 */
			if (i[84] == null)
			{
				return 0.006622967068085217;
			}
			else if (((System.Double) i[84]) <= 24.5)
			{
				return - 0.01139568233311512;
			}
			else
			{
				return 1.314495192585946;
			}
		}
	}
	class FacialExpressionMotionBooster_0_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_10 */
			if (i[10] == null)
			{
				return - 0.004300181172370949;
			}
			else if (((System.Double) i[10]) <= 8.5)
			{
				return 0.02617606464385031;
			}
			else
			{
				return - 0.6579687800830701;
			}
		}
	}
	class FacialExpressionMotionBooster_0_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_84 */
			if (i[84] == null)
			{
				return 0.004168617950573126;
			}
			else if (((System.Double) i[84]) <= 8.5)
			{
				return - 0.08992761518862994;
			}
			else
			{
				return 0.2579995420312898;
			}
		}
	}
	class FacialExpressionMotionBooster_0_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_39 */
			if (i[39] == null)
			{
				return - 0.01304359756690231;
			}
			else if (((System.Double) i[39]) <= 1.5)
			{
				return 0.290125909839437;
			}
			else
			{
				return - 0.08711365892980623;
			}
		}
	}
	class FacialExpressionMotionBooster_1_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_98 */
			if (i[98] == null)
			{
				return 0.4336287667763659;
			}
			else if (((System.Double) i[98]) <= 6.5)
			{
				return 0.07499999999999837;
			}
			else
			{
				return 1.816974169741724;
			}
		}
	}
	class FacialExpressionMotionBooster_1_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return 0.1267363288433996;
			}
			else if (((System.Double) i[74]) <= 6.5)
			{
				return 0.5499774215337642;
			}
			else
			{
				return - 0.5918503403073156;
			}
		}
	}
	class FacialExpressionMotionBooster_1_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_88 */
			if (i[88] == null)
			{
				return - 0.007297098206902259;
			}
			else if (((System.Double) i[88]) <= 3.5)
			{
				return - 0.4116165698982442;
			}
			else
			{
				return 0.6613520430892404;
			}
		}
	}
	class FacialExpressionMotionBooster_1_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return - 0.002103489593613565;
			}
			else if (((System.Double) i[74]) <= 1.5)
			{
				return 0.520903876315354;
			}
			else
			{
				return - 0.3359142107075864;
			}
		}
	}
	class FacialExpressionMotionBooster_1_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_44 */
			if (i[44] == null)
			{
				return 0.003550233107020833;
			}
			else if (((System.Double) i[44]) <= 8.5)
			{
				return - 0.1881105045936446;
			}
			else
			{
				return 0.7489067464509802;
			}
		}
	}
	class FacialExpressionMotionBooster_1_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return - 0.0078577018306805;
			}
			else if (((System.Double) i[74]) <= 15.5)
			{
				return 0.1026015856771785;
			}
			else
			{
				return - 1.068148923110869;
			}
		}
	}
	class FacialExpressionMotionBooster_1_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_26 */
			if (i[26] == null)
			{
				return - 0.0143457660693966;
			}
			else if (((System.Double) i[26]) <= 7.5)
			{
				return - 0.1583641000382253;
			}
			else
			{
				return 0.5919222288532888;
			}
		}
	}
	class FacialExpressionMotionBooster_1_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_65 */
			if (i[65] == null)
			{
				return 0.005213354117083095;
			}
			else if (((System.Double) i[65]) <= 1.5)
			{
				return 0.5239666677564015;
			}
			else
			{
				return - 0.1984276512047484;
			}
		}
	}
	class FacialExpressionMotionBooster_1_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_86 */
			if (i[86] == null)
			{
				return - 0.01279234983136983;
			}
			else if (((System.Double) i[86]) <= 1.5)
			{
				return - 0.3432757499711737;
			}
			else
			{
				return 0.2619154452976964;
			}
		}
	}
	class FacialExpressionMotionBooster_1_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_76 */
			if (i[76] == null)
			{
				return 0.00178166631482681;
			}
			else if (((System.Double) i[76]) <= 6.5)
			{
				return 0.1749902147392682;
			}
			else
			{
				return - 0.3070756856494214;
			}
		}
	}
	class FacialExpressionMotionBooster_1_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_46 */
			if (i[46] == null)
			{
				return - 0.02791277168551624;
			}
			else if (((System.Double) i[46]) <= 26.5)
			{
				return - 0.08292057853197446;
			}
			else
			{
				return 1.255755867394273;
			}
		}
	}
	class FacialExpressionMotionBooster_1_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_58 */
			if (i[58] == null)
			{
				return 0.0159286460074801;
			}
			else if (((System.Double) i[58]) <= 10.5)
			{
				return 0.07438735337700335;
			}
			else
			{
				return - 0.7851063659275007;
			}
		}
	}
	class FacialExpressionMotionBooster_1_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_24 */
			if (i[24] == null)
			{
				return - 0.01705393246868233;
			}
			else if (((System.Double) i[24]) <= 2.5)
			{
				return - 0.1463827479004271;
			}
			else
			{
				return 0.4766826235807219;
			}
		}
	}
	class FacialExpressionMotionBooster_1_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_56 */
			if (i[56] == null)
			{
				return 0.01029200509450367;
			}
			else if (((System.Double) i[56]) <= 3.5)
			{
				return 0.08994880988578003;
			}
			else
			{
				return - 0.4804572404381654;
			}
		}
	}
	class FacialExpressionMotionBooster_1_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_53 */
			if (i[53] == null)
			{
				return - 0.01173317475343726;
			}
			else if (((System.Double) i[53]) <= 3.5)
			{
				return - 0.2845804098369631;
			}
			else
			{
				return 0.2007126145068306;
			}
		}
	}
	class FacialExpressionMotionBooster_1_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_72 */
			if (i[72] == null)
			{
				return - 0.003712781900163872;
			}
			else if (((System.Double) i[72]) <= 1.5)
			{
				return 0.2061324159715595;
			}
			else
			{
				return - 0.2403266709731406;
			}
		}
	}
	class FacialExpressionMotionBooster_1_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return - 0.007411412131583324;
			}
			else if (((System.Double) i[28]) <= 19.5)
			{
				return - 0.08950848951418961;
			}
			else
			{
				return 0.5688776079412593;
			}
		}
	}
	class FacialExpressionMotionBooster_1_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_54 */
			if (i[54] == null)
			{
				return - 0.0065396606918491;
			}
			else if (((System.Double) i[54]) <= 2.5)
			{
				return 0.07231951089544237;
			}
			else
			{
				return - 0.453380513175984;
			}
		}
	}
	class FacialExpressionMotionBooster_1_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return - 0.001269672332320735;
			}
			else if (((System.Double) i[28]) <= 36.5)
			{
				return - 0.02270316271455852;
			}
			else
			{
				return 1.812118942004299;
			}
		}
	}
	class FacialExpressionMotionBooster_1_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_78 */
			if (i[78] == null)
			{
				return - 0.004918790817489931;
			}
			else if (((System.Double) i[78]) <= 17.5)
			{
				return 0.04208749836038156;
			}
			else
			{
				return - 0.6016088565861087;
			}
		}
	}
	class FacialExpressionMotionBooster_1_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_44 */
			if (i[44] == null)
			{
				return - 0.009767149238572762;
			}
			else if (((System.Double) i[44]) <= 6.5)
			{
				return - 0.1048229816101252;
			}
			else
			{
				return 0.326081342444798;
			}
		}
	}
	class FacialExpressionMotionBooster_1_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_27 */
			if (i[27] == null)
			{
				return 0.006234696188052808;
			}
			else if (((System.Double) i[27]) <= 1.5)
			{
				return 0.2156358385305352;
			}
			else
			{
				return - 0.2076521961206486;
			}
		}
	}
	class FacialExpressionMotionBooster_1_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_42 */
			if (i[42] == null)
			{
				return - 0.009898922451011373;
			}
			else if (((System.Double) i[42]) <= 3.5)
			{
				return - 0.1542685491941601;
			}
			else
			{
				return 0.2055653762229247;
			}
		}
	}
	class FacialExpressionMotionBooster_1_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_91 */
			if (i[91] == null)
			{
				return 0.004356913454313275;
			}
			else if (((System.Double) i[91]) <= 5.5)
			{
				return 0.06070717463180776;
			}
			else
			{
				return - 0.4727826569224549;
			}
		}
	}
	class FacialExpressionMotionBooster_1_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_92 */
			if (i[92] == null)
			{
				return 0.001387466521388004;
			}
			else if (((System.Double) i[92]) <= 3.5)
			{
				return - 0.1207128318905408;
			}
			else
			{
				return 0.2616227071434736;
			}
		}
	}
	class FacialExpressionMotionBooster_1_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_67 */
			if (i[67] == null)
			{
				return - 7.930342386240804e-5;
			}
			else if (((System.Double) i[67]) <= 1.5)
			{
				return 0.2015078030239908;
			}
			else
			{
				return - 0.1109950582674198;
			}
		}
	}
	class FacialExpressionMotionBooster_1_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_4 */
			if (i[4] == null)
			{
				return - 0.008768155074626012;
			}
			else if (((System.Double) i[4]) <= 17.5)
			{
				return - 0.03852782460085978;
			}
			else
			{
				return 0.6694633697755034;
			}
		}
	}
	class FacialExpressionMotionBooster_1_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_58 */
			if (i[58] == null)
			{
				return 0.01093330403041707;
			}
			else if (((System.Double) i[58]) <= 13.5)
			{
				return 0.04852104583345604;
			}
			else
			{
				return - 0.7965799959989044;
			}
		}
	}
	class FacialExpressionMotionBooster_1_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_50 */
			if (i[50] == null)
			{
				return - 0.00176581473611845;
			}
			else if (((System.Double) i[50]) <= 23.5)
			{
				return - 0.03051963207910034;
			}
			else
			{
				return 0.9616709092182802;
			}
		}
	}
	class FacialExpressionMotionBooster_1_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_83 */
			if (i[83] == null)
			{
				return 0.01354183562559259;
			}
			else if (((System.Double) i[83]) <= 10.5)
			{
				return 0.04794547792644197;
			}
			else
			{
				return - 0.7542014957418712;
			}
		}
	}
	class FacialExpressionMotionBooster_2_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_70 */
			if (i[70] == null)
			{
				return - 0.0256354786371055;
			}
			else if (((System.Double) i[70]) <= 3.5)
			{
				return 0.2072485207100519;
			}
			else
			{
				return - 0.6591549295774405;
			}
		}
	}
	class FacialExpressionMotionBooster_2_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_22 */
			if (i[22] == null)
			{
				return 0.08288706959411162;
			}
			else if (((System.Double) i[22]) <= 25.5)
			{
				return 0.05946168358503729;
			}
			else
			{
				return 1.928691738374092;
			}
		}
	}
	class FacialExpressionMotionBooster_2_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_48 */
			if (i[48] == null)
			{
				return 0.02466714090821176;
			}
			else if (((System.Double) i[48]) <= 1.5)
			{
				return 0.1653737125912929;
			}
			else
			{
				return - 0.3674801787947428;
			}
		}
	}
	class FacialExpressionMotionBooster_2_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_2 */
			if (i[2] == null)
			{
				return 0.03518104451960435;
			}
			else if (((System.Double) i[2]) <= 4.5)
			{
				return - 0.04426050593288614;
			}
			else
			{
				return 0.6775132834397591;
			}
		}
	}
	class FacialExpressionMotionBooster_2_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_81 */
			if (i[81] == null)
			{
				return 0.0033543895114251;
			}
			else if (((System.Double) i[81]) <= 2.5)
			{
				return 0.1025337721355669;
			}
			else
			{
				return - 0.4194816914407865;
			}
		}
	}
	class FacialExpressionMotionBooster_2_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_35 */
			if (i[35] == null)
			{
				return 0.01706113458628167;
			}
			else if (((System.Double) i[35]) <= 1.5)
			{
				return - 0.3085205767899643;
			}
			else
			{
				return 0.1713796443787855;
			}
		}
	}
	class FacialExpressionMotionBooster_2_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_5 */
			if (i[5] == null)
			{
				return - 0.002099381674646908;
			}
			else if (((System.Double) i[5]) <= 1.5)
			{
				return - 0.07195144534406701;
			}
			else
			{
				return 0.4282009305809485;
			}
		}
	}
	class FacialExpressionMotionBooster_2_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return 0.01998606991305578;
			}
			else if (((System.Double) i[74]) <= 1.5)
			{
				return 0.2396549254075005;
			}
			else
			{
				return - 0.1265683342504503;
			}
		}
	}
	class FacialExpressionMotionBooster_2_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_78 */
			if (i[78] == null)
			{
				return 0.007638305632671197;
			}
			else if (((System.Double) i[78]) <= 2.5)
			{
				return - 0.2795449228499984;
			}
			else
			{
				return 0.206213898718491;
			}
		}
	}
	class FacialExpressionMotionBooster_2_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_76 */
			if (i[76] == null)
			{
				return 0.005979923106860087;
			}
			else if (((System.Double) i[76]) <= 4.5)
			{
				return - 0.1564746256506241;
			}
			else
			{
				return 0.1825384480554083;
			}
		}
	}
	class FacialExpressionMotionBooster_2_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_45 */
			if (i[45] == null)
			{
				return - 0.006810715968449652;
			}
			else if (((System.Double) i[45]) <= 5.5)
			{
				return 0.1259551018547744;
			}
			else
			{
				return - 0.3383001333309743;
			}
		}
	}
	class FacialExpressionMotionBooster_2_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_14 */
			if (i[14] == null)
			{
				return - 6.031949457774359e-4;
			}
			else if (((System.Double) i[14]) <= 4.5)
			{
				return - 0.04502585388256131;
			}
			else
			{
				return 0.6579039887361284;
			}
		}
	}
	class FacialExpressionMotionBooster_2_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_15 */
			if (i[15] == null)
			{
				return 2.938074529988851e-4;
			}
			else if (((System.Double) i[15]) <= 1.5)
			{
				return 0.09429682318008937;
			}
			else
			{
				return - 0.4225501443836685;
			}
		}
	}
	class FacialExpressionMotionBooster_2_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_37 */
			if (i[37] == null)
			{
				return 0.01100979709768642;
			}
			else if (((System.Double) i[37]) <= 1.5)
			{
				return - 0.2526782528879373;
			}
			else
			{
				return 0.1317790876705955;
			}
		}
	}
	class FacialExpressionMotionBooster_2_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_55 */
			if (i[55] == null)
			{
				return - 6.349416350329983e-4;
			}
			else if (((System.Double) i[55]) <= 2.5)
			{
				return 0.2348592824511919;
			}
			else
			{
				return - 0.1306195916581437;
			}
		}
	}
	class FacialExpressionMotionBooster_2_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_26 */
			if (i[26] == null)
			{
				return 0.01249512145101768;
			}
			else if (((System.Double) i[26]) <= 2.5)
			{
				return - 0.07279260320597082;
			}
			else
			{
				return 0.2569348132373421;
			}
		}
	}
	class FacialExpressionMotionBooster_2_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_92 */
			if (i[92] == null)
			{
				return - 0.002850437733852316;
			}
			else if (((System.Double) i[92]) <= 10.5)
			{
				return 0.04125714515876187;
			}
			else
			{
				return - 0.5633949147767968;
			}
		}
	}
	class FacialExpressionMotionBooster_2_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_80 */
			if (i[80] == null)
			{
				return 0.003418884582199911;
			}
			else if (((System.Double) i[80]) <= 18.5)
			{
				return - 0.02387365850852115;
			}
			else
			{
				return 0.6562191649595402;
			}
		}
	}
	class FacialExpressionMotionBooster_2_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_17 */
			if (i[17] == null)
			{
				return 5.551135309531476e-4;
			}
			else if (((System.Double) i[17]) <= 1.5)
			{
				return 0.06635684706036353;
			}
			else
			{
				return - 0.2943778062994283;
			}
		}
	}
	class FacialExpressionMotionBooster_2_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_41 */
			if (i[41] == null)
			{
				return 0.01302670352012626;
			}
			else if (((System.Double) i[41]) <= 2.5)
			{
				return - 0.1354803043636434;
			}
			else
			{
				return 0.1579616149378524;
			}
		}
	}
	class FacialExpressionMotionBooster_2_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_56 */
			if (i[56] == null)
			{
				return - 2.343184429483423e-4;
			}
			else if (((System.Double) i[56]) <= 1.5)
			{
				return 0.07907998996127557;
			}
			else
			{
				return - 0.2599111024370579;
			}
		}
	}
	class FacialExpressionMotionBooster_2_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_31 */
			if (i[31] == null)
			{
				return 0.004256481896267613;
			}
			else if (((System.Double) i[31]) <= 8.5)
			{
				return - 0.04535996576489722;
			}
			else
			{
				return 0.4007645561783105;
			}
		}
	}
	class FacialExpressionMotionBooster_2_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return 0.00494668466761848;
			}
			else if (((System.Double) i[30]) <= 20.5)
			{
				return 0.04585797268562221;
			}
			else
			{
				return - 0.434869436219418;
			}
		}
	}
	class FacialExpressionMotionBooster_2_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_3 */
			if (i[3] == null)
			{
				return 0.003082304030283642;
			}
			else if (((System.Double) i[3]) <= 3.5)
			{
				return - 0.0304030192174797;
			}
			else
			{
				return 0.487326873816342;
			}
		}
	}
	class FacialExpressionMotionBooster_2_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_54 */
			if (i[54] == null)
			{
				return - 0.003290482863396231;
			}
			else if (((System.Double) i[54]) <= 2.5)
			{
				return 0.0469788613874712;
			}
			else
			{
				return - 0.3743854693016442;
			}
		}
	}
	class FacialExpressionMotionBooster_2_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_67 */
			if (i[67] == null)
			{
				return 0.007831135614888865;
			}
			else if (((System.Double) i[67]) <= 1.5)
			{
				return - 0.1980900295808442;
			}
			else
			{
				return 0.09247282192241874;
			}
		}
	}
	class FacialExpressionMotionBooster_2_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return - 0.009118612728015076;
			}
			else if (((System.Double) i[74]) <= 1.5)
			{
				return 0.1284907086411866;
			}
			else
			{
				return - 0.1101097195995543;
			}
		}
	}
	class FacialExpressionMotionBooster_2_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_87 */
			if (i[87] == null)
			{
				return 0.008307770409093679;
			}
			else if (((System.Double) i[87]) <= 16.5)
			{
				return - 0.01018561382903739;
			}
			else
			{
				return 0.9969936449655087;
			}
		}
	}
	class FacialExpressionMotionBooster_2_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_90 */
			if (i[90] == null)
			{
				return - 0.006789717337177654;
			}
			else if (((System.Double) i[90]) <= 24.5)
			{
				return 0.00959856270441278;
			}
			else
			{
				return - 1.110283843638015;
			}
		}
	}
	class FacialExpressionMotionBooster_2_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_76 */
			if (i[76] == null)
			{
				return 0.001957389427650363;
			}
			else if (((System.Double) i[76]) <= 4.5)
			{
				return - 0.1181483962468141;
			}
			else
			{
				return 0.1309233024419139;
			}
		}
	}
	class FacialExpressionMotionBooster_3_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_25 */
			if (i[25] == null)
			{
				return - 0.3460039536853837;
			}
			else if (((System.Double) i[25]) <= 1.5)
			{
				return - 0.7363476218438083;
			}
			else
			{
				return 0.01566920565833981;
			}
		}
	}
	class FacialExpressionMotionBooster_3_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_48 */
			if (i[48] == null)
			{
				return - 0.01843663981910962;
			}
			else if (((System.Double) i[48]) <= 1.5)
			{
				return 0.2277984983028123;
			}
			else
			{
				return - 0.4879551999503694;
			}
		}
	}
	class FacialExpressionMotionBooster_3_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return - 0.002831906795371125;
			}
			else if (((System.Double) i[30]) <= 1.5)
			{
				return - 0.4182522166380778;
			}
			else
			{
				return 0.2897339243361226;
			}
		}
	}
	class FacialExpressionMotionBooster_3_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_67 */
			if (i[67] == null)
			{
				return 0.006774526734357489;
			}
			else if (((System.Double) i[67]) <= 4.5)
			{
				return 0.2884952351657023;
			}
			else
			{
				return - 0.3137496048928714;
			}
		}
	}
	class FacialExpressionMotionBooster_3_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_79 */
			if (i[79] == null)
			{
				return 0.00471256181621551;
			}
			else if (((System.Double) i[79]) <= 1.5)
			{
				return - 0.2723698726052005;
			}
			else
			{
				return 0.313497410835775;
			}
		}
	}
	class FacialExpressionMotionBooster_3_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_88 */
			if (i[88] == null)
			{
				return 0.01358601667797068;
			}
			else if (((System.Double) i[88]) <= 1.5)
			{
				return 0.2263840269544212;
			}
			else
			{
				return - 0.229667524111395;
			}
		}
	}
	class FacialExpressionMotionBooster_3_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_25 */
			if (i[25] == null)
			{
				return 0.01340018165178563;
			}
			else if (((System.Double) i[25]) <= 1.5)
			{
				return - 0.2637884332536628;
			}
			else
			{
				return 0.2003526065055952;
			}
		}
	}
	class FacialExpressionMotionBooster_3_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_33 */
			if (i[33] == null)
			{
				return 0.004226530834089836;
			}
			else if (((System.Double) i[33]) <= 7.5)
			{
				return 0.1018402407180693;
			}
			else
			{
				return - 0.3493229541344443;
			}
		}
	}
	class FacialExpressionMotionBooster_3_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_32 */
			if (i[32] == null)
			{
				return 0.004619657402412191;
			}
			else if (((System.Double) i[32]) <= 12.5)
			{
				return - 0.1060595605600914;
			}
			else
			{
				return 0.5280894838400772;
			}
		}
	}
	class FacialExpressionMotionBooster_3_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_4 */
			if (i[4] == null)
			{
				return 0.004352101772211905;
			}
			else if (((System.Double) i[4]) <= 1.5)
			{
				return 0.1294829145543415;
			}
			else
			{
				return - 0.303089330301161;
			}
		}
	}
	class FacialExpressionMotionBooster_3_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_40 */
			if (i[40] == null)
			{
				return 0.00653544220711854;
			}
			else if (((System.Double) i[40]) <= 21.5)
			{
				return - 0.04388184802074557;
			}
			else
			{
				return 0.7980236085633028;
			}
		}
	}
	class FacialExpressionMotionBooster_3_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_80 */
			if (i[80] == null)
			{
				return 0.01604396470300177;
			}
			else if (((System.Double) i[80]) <= 18.5)
			{
				return 0.0487335139584241;
			}
			else
			{
				return - 0.8908638824657919;
			}
		}
	}
	class FacialExpressionMotionBooster_3_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_94 */
			if (i[94] == null)
			{
				return 0.002966673962812796;
			}
			else if (((System.Double) i[94]) <= 9.5)
			{
				return 0.04803499466560625;
			}
			else
			{
				return - 0.5117709339655632;
			}
		}
	}
	class FacialExpressionMotionBooster_3_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return 0.01225924644140212;
			}
			else if (((System.Double) i[28]) <= 23.5)
			{
				return - 0.03825439871591531;
			}
			else
			{
				return 0.8386803932382369;
			}
		}
	}
	class FacialExpressionMotionBooster_3_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_31 */
			if (i[31] == null)
			{
				return 0.004459754747955133;
			}
			else if (((System.Double) i[31]) <= 9.5)
			{
				return 0.07405679706010799;
			}
			else
			{
				return - 0.5338079408876742;
			}
		}
	}
	class FacialExpressionMotionBooster_3_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_42 */
			if (i[42] == null)
			{
				return 0.002877777790168141;
			}
			else if (((System.Double) i[42]) <= 18.5)
			{
				return - 0.05526091533859559;
			}
			else
			{
				return 0.6236708072523027;
			}
		}
	}
	class FacialExpressionMotionBooster_3_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_39 */
			if (i[39] == null)
			{
				return 0.006284489441089772;
			}
			else if (((System.Double) i[39]) <= 8.5)
			{
				return 0.08088881813407122;
			}
			else
			{
				return - 0.3813700105071222;
			}
		}
	}
	class FacialExpressionMotionBooster_3_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_23 */
			if (i[23] == null)
			{
				return 0.009203940752782436;
			}
			else if (((System.Double) i[23]) <= 3.5)
			{
				return - 0.09422683751843227;
			}
			else
			{
				return 0.412895720534742;
			}
		}
	}
	class FacialExpressionMotionBooster_3_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_33 */
			if (i[33] == null)
			{
				return - 0.007525605324289396;
			}
			else if (((System.Double) i[33]) <= 8.5)
			{
				return 0.06257311747241115;
			}
			else
			{
				return - 0.4045092803757903;
			}
		}
	}
	class FacialExpressionMotionBooster_3_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return 0.002574373661999485;
			}
			else if (((System.Double) i[74]) <= 16.5)
			{
				return - 0.05071655111130816;
			}
			else
			{
				return 0.7955045576279884;
			}
		}
	}
	class FacialExpressionMotionBooster_3_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_93 */
			if (i[93] == null)
			{
				return 0.005866522593771241;
			}
			else if (((System.Double) i[93]) <= 1.5)
			{
				return 0.1247793108573271;
			}
			else
			{
				return - 0.2548358534442085;
			}
		}
	}
	class FacialExpressionMotionBooster_3_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_77 */
			if (i[77] == null)
			{
				return 0.008157801942012063;
			}
			else if (((System.Double) i[77]) <= 1.5)
			{
				return - 0.1888188253746513;
			}
			else
			{
				return 0.1719962809832861;
			}
		}
	}
	class FacialExpressionMotionBooster_3_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_35 */
			if (i[35] == null)
			{
				return - 0.01854751009538188;
			}
			else if (((System.Double) i[35]) <= 4.5)
			{
				return 0.1226291176336743;
			}
			else
			{
				return - 0.2341341795688762;
			}
		}
	}
	class FacialExpressionMotionBooster_3_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_61 */
			if (i[61] == null)
			{
				return 2.189180933519487e-4;
			}
			else if (((System.Double) i[61]) <= 4.5)
			{
				return - 0.152502800271626;
			}
			else
			{
				return 0.2134769035634383;
			}
		}
	}
	class FacialExpressionMotionBooster_3_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_96 */
			if (i[96] == null)
			{
				return 0.001853783230649102;
			}
			else if (((System.Double) i[96]) <= 4.5)
			{
				return 0.07663864842570927;
			}
			else
			{
				return - 0.3354071774467598;
			}
		}
	}
	class FacialExpressionMotionBooster_3_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_78 */
			if (i[78] == null)
			{
				return 1.000107104746935e-4;
			}
			else if (((System.Double) i[78]) <= 13.5)
			{
				return - 0.06905159524659503;
			}
			else
			{
				return 0.3650680699504719;
			}
		}
	}
	class FacialExpressionMotionBooster_3_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_70 */
			if (i[70] == null)
			{
				return - 0.004342088283431377;
			}
			else if (((System.Double) i[70]) <= 7.5)
			{
				return 0.05731357716055628;
			}
			else
			{
				return - 0.459744946991677;
			}
		}
	}
	class FacialExpressionMotionBooster_3_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_72 */
			if (i[72] == null)
			{
				return 0.00127899198796416;
			}
			else if (((System.Double) i[72]) <= 12.5)
			{
				return - 0.04376014592590358;
			}
			else
			{
				return 0.4962352077272504;
			}
		}
	}
	class FacialExpressionMotionBooster_3_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_73 */
			if (i[73] == null)
			{
				return - 0.004563997421980243;
			}
			else if (((System.Double) i[73]) <= 18.5)
			{
				return 0.02010836397153207;
			}
			else
			{
				return - 0.8679999919915245;
			}
		}
	}
	class FacialExpressionMotionBooster_3_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_9 */
			if (i[9] == null)
			{
				return - 0.008049727539192602;
			}
			else if (((System.Double) i[9]) <= 15.5)
			{
				return - 0.02273858669440292;
			}
			else
			{
				return 1.414126096866004;
			}
		}
	}
	class FacialExpressionMotionBooster_4_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_54 */
			if (i[54] == null)
			{
				return - 0.6427942471382691;
			}
			else if (((System.Double) i[54]) <= 2.5)
			{
				return - 0.8665931642778828;
			}
			else
			{
				return 0.2448979591835932;
			}
		}
	}
	class FacialExpressionMotionBooster_4_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_92 */
			if (i[92] == null)
			{
				return - 0.2119643525925599;
			}
			else if (((System.Double) i[92]) <= 1.5)
			{
				return 0.148949374110922;
			}
			else
			{
				return - 0.7469657140235191;
			}
		}
	}
	class FacialExpressionMotionBooster_4_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_56 */
			if (i[56] == null)
			{
				return - 0.08220122798335709;
			}
			else if (((System.Double) i[56]) <= 1.5)
			{
				return - 0.5084562338432308;
			}
			else
			{
				return 0.5577692647652619;
			}
		}
	}
	class FacialExpressionMotionBooster_4_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_89 */
			if (i[89] == null)
			{
				return - 0.05252428104069242;
			}
			else if (((System.Double) i[89]) <= 1.5)
			{
				return 0.2995254802637512;
			}
			else
			{
				return - 0.833744395581786;
			}
		}
	}
	class FacialExpressionMotionBooster_4_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_54 */
			if (i[54] == null)
			{
				return - 0.03741126888077537;
			}
			else if (((System.Double) i[54]) <= 1.5)
			{
				return - 0.3803638939411283;
			}
			else
			{
				return 0.4879090785167231;
			}
		}
	}
	class FacialExpressionMotionBooster_4_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_85 */
			if (i[85] == null)
			{
				return - 0.02617175808759306;
			}
			else if (((System.Double) i[85]) <= 1.5)
			{
				return 0.2148107869149565;
			}
			else
			{
				return - 0.7217896686621996;
			}
		}
	}
	class FacialExpressionMotionBooster_4_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_56 */
			if (i[56] == null)
			{
				return 5.308046299516311e-4;
			}
			else if (((System.Double) i[56]) <= 5.5)
			{
				return - 0.1547990664706818;
			}
			else
			{
				return 0.7449520983255814;
			}
		}
	}
	class FacialExpressionMotionBooster_4_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_91 */
			if (i[91] == null)
			{
				return - 0.004946750556211666;
			}
			else if (((System.Double) i[91]) <= 3.5)
			{
				return 0.1413974779739525;
			}
			else
			{
				return - 0.7784869720259805;
			}
		}
	}
	class FacialExpressionMotionBooster_4_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_52 */
			if (i[52] == null)
			{
				return 0.002200213021181386;
			}
			else if (((System.Double) i[52]) <= 2.5)
			{
				return - 0.1491323218540394;
			}
			else
			{
				return 0.5918037771825052;
			}
		}
	}
	class FacialExpressionMotionBooster_4_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_82 */
			if (i[82] == null)
			{
				return 5.800047321097912e-4;
			}
			else if (((System.Double) i[82]) <= 1.5)
			{
				return 0.3447478459367009;
			}
			else
			{
				return - 0.2561536559223465;
			}
		}
	}
	class FacialExpressionMotionBooster_4_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_32 */
			if (i[32] == null)
			{
				return 0.007030082523706999;
			}
			else if (((System.Double) i[32]) <= 3.5)
			{
				return - 0.2157880246175248;
			}
			else
			{
				return 0.3457394018522571;
			}
		}
	}
	class FacialExpressionMotionBooster_4_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_23 */
			if (i[23] == null)
			{
				return - 0.015157779313102;
			}
			else if (((System.Double) i[23]) <= 3.5)
			{
				return 0.1663867552234149;
			}
			else
			{
				return - 0.6257404134442412;
			}
		}
	}
	class FacialExpressionMotionBooster_4_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_54 */
			if (i[54] == null)
			{
				return - 0.00667721218128257;
			}
			else if (((System.Double) i[54]) <= 3.5)
			{
				return - 0.128611688330494;
			}
			else
			{
				return 0.5029717718046765;
			}
		}
	}
	class FacialExpressionMotionBooster_4_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_99 */
			if (i[99] == null)
			{
				return - 0.004098057536131693;
			}
			else if (((System.Double) i[99]) <= 1.5)
			{
				return 0.1791371736743392;
			}
			else
			{
				return - 0.4363018745069828;
			}
		}
	}
	class FacialExpressionMotionBooster_4_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_22 */
			if (i[22] == null)
			{
				return - 0.008693519787147525;
			}
			else if (((System.Double) i[22]) <= 1.5)
			{
				return 0.100282394335371;
			}
			else
			{
				return - 0.4919653212792822;
			}
		}
	}
	class FacialExpressionMotionBooster_4_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_48 */
			if (i[48] == null)
			{
				return - 0.003603493050734033;
			}
			else if (((System.Double) i[48]) <= 1.5)
			{
				return - 0.1936921671253584;
			}
			else
			{
				return 0.3623527881476113;
			}
		}
	}
	class FacialExpressionMotionBooster_4_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_78 */
			if (i[78] == null)
			{
				return - 0.001983098368906107;
			}
			else if (((System.Double) i[78]) <= 2.5)
			{
				return 0.2974695668108344;
			}
			else
			{
				return - 0.2264427829438378;
			}
		}
	}
	class FacialExpressionMotionBooster_4_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_72 */
			if (i[72] == null)
			{
				return 0.006681848131475652;
			}
			else if (((System.Double) i[72]) <= 1.5)
			{
				return - 0.280165367948231;
			}
			else
			{
				return 0.23407913958148;
			}
		}
	}
	class FacialExpressionMotionBooster_4_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_96 */
			if (i[96] == null)
			{
				return - 0.01071651113499869;
			}
			else if (((System.Double) i[96]) <= 2.5)
			{
				return 0.1012542989200531;
			}
			else
			{
				return - 0.4669320067388154;
			}
		}
	}
	class FacialExpressionMotionBooster_4_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_57 */
			if (i[57] == null)
			{
				return 0.001059773566141839;
			}
			else if (((System.Double) i[57]) <= 5.5)
			{
				return - 0.1464143650897992;
			}
			else
			{
				return 0.2454592643010645;
			}
		}
	}
	class FacialExpressionMotionBooster_4_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_42 */
			if (i[42] == null)
			{
				return - 0.005252192695550172;
			}
			else if (((System.Double) i[42]) <= 9.5)
			{
				return 0.1128382658727579;
			}
			else
			{
				return - 0.4958225979214859;
			}
		}
	}
	class FacialExpressionMotionBooster_4_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_32 */
			if (i[32] == null)
			{
				return - 0.01178855871234475;
			}
			else if (((System.Double) i[32]) <= 31.5)
			{
				return - 0.03768254646242193;
			}
			else
			{
				return 1.614069138530965;
			}
		}
	}
	class FacialExpressionMotionBooster_4_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_87 */
			if (i[87] == null)
			{
				return 0.004491057775741039;
			}
			else if (((System.Double) i[87]) <= 1.5)
			{
				return 0.1034575988380985;
			}
			else
			{
				return - 0.4316949432810944;
			}
		}
	}
	class FacialExpressionMotionBooster_4_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_46 */
			if (i[46] == null)
			{
				return - 0.01001263006841444;
			}
			else if (((System.Double) i[46]) <= 1.5)
			{
				return - 0.1670044110178288;
			}
			else
			{
				return 0.2660701857676459;
			}
		}
	}
	class FacialExpressionMotionBooster_4_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_76 */
			if (i[76] == null)
			{
				return - 0.00620890876273126;
			}
			else if (((System.Double) i[76]) <= 21.5)
			{
				return 0.02747468721261087;
			}
			else
			{
				return - 1.254835686758401;
			}
		}
	}
	class FacialExpressionMotionBooster_4_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_67 */
			if (i[67] == null)
			{
				return - 0.00275625551544178;
			}
			else if (((System.Double) i[67]) <= 3.5)
			{
				return 0.1579756882953865;
			}
			else
			{
				return - 0.2116232760901305;
			}
		}
	}
	class FacialExpressionMotionBooster_4_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_32 */
			if (i[32] == null)
			{
				return 1.015071293889794e-4;
			}
			else if (((System.Double) i[32]) <= 5.5)
			{
				return - 0.1478910829103761;
			}
			else
			{
				return 0.3459564249638662;
			}
		}
	}
	class FacialExpressionMotionBooster_4_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_2 */
			if (i[2] == null)
			{
				return - 0.0144048423257018;
			}
			else if (((System.Double) i[2]) <= 1.5)
			{
				return 0.1046967025109182;
			}
			else
			{
				return - 0.3717282350718927;
			}
		}
	}
	class FacialExpressionMotionBooster_4_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_56 */
			if (i[56] == null)
			{
				return - 0.002795913289757356;
			}
			else if (((System.Double) i[56]) <= 11.5)
			{
				return - 0.04126020518396706;
			}
			else
			{
				return 1.115171044580771;
			}
		}
	}
	class FacialExpressionMotionBooster_4_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_66 */
			if (i[66] == null)
			{
				return 0.003470557258237808;
			}
			else if (((System.Double) i[66]) <= 8.5)
			{
				return 0.05360442435892802;
			}
			else
			{
				return - 0.5626623167967358;
			}
		}
	}
	class FacialExpressionMotionBooster_5_0
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return 0.682829268292692;
			}
			else if (((System.Double) i[30]) <= 3.5)
			{
				return 1.336141906873646;
			}
			else
			{
				return - 0.5853658536584891;
			}
		}
	}
	class FacialExpressionMotionBooster_5_1
	{
		public static double classify(System.Object[] i)
		{
			/* p_72 */
			if (i[72] == null)
			{
				return - 0.03525985998812943;
			}
			else if (((System.Double) i[72]) <= 14.5)
			{
				return - 0.2722024358698922;
			}
			else
			{
				return 1.867615990040599;
			}
		}
	}
	class FacialExpressionMotionBooster_5_2
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return 0.05177031415192357;
			}
			else if (((System.Double) i[28]) <= 1.5)
			{
				return 0.3681728756649333;
			}
			else
			{
				return - 0.5285331746919705;
			}
		}
	}
	class FacialExpressionMotionBooster_5_3
	{
		public static double classify(System.Object[] i)
		{
			/* p_70 */
			if (i[70] == null)
			{
				return - 0.04260468204481801;
			}
			else if (((System.Double) i[70]) <= 1.5)
			{
				return - 0.4213529080819775;
			}
			else
			{
				return 0.5147734399316716;
			}
		}
	}
	class FacialExpressionMotionBooster_5_4
	{
		public static double classify(System.Object[] i)
		{
			/* p_51 */
			if (i[51] == null)
			{
				return 0.02188356641801028;
			}
			else if (((System.Double) i[51]) <= 3.5)
			{
				return 0.3512688406720415;
			}
			else
			{
				return - 0.3137966200368787;
			}
		}
	}
	class FacialExpressionMotionBooster_5_5
	{
		public static double classify(System.Object[] i)
		{
			/* p_68 */
			if (i[68] == null)
			{
				return - 0.02003328401850291;
			}
			else if (((System.Double) i[68]) <= 2.5)
			{
				return - 0.2130598450470028;
			}
			else
			{
				return 0.544257005432221;
			}
		}
	}
	class FacialExpressionMotionBooster_5_6
	{
		public static double classify(System.Object[] i)
		{
			/* p_32 */
			if (i[32] == null)
			{
				return 0.0055881884480682;
			}
			else if (((System.Double) i[32]) <= 1.5)
			{
				return 0.1917223134448105;
			}
			else
			{
				return - 0.3976564700484809;
			}
		}
	}
	class FacialExpressionMotionBooster_5_7
	{
		public static double classify(System.Object[] i)
		{
			/* p_74 */
			if (i[74] == null)
			{
				return - 0.04014732329437548;
			}
			else if (((System.Double) i[74]) <= 1.5)
			{
				return - 0.4002621520918211;
			}
			else
			{
				return 0.220755511290924;
			}
		}
	}
	class FacialExpressionMotionBooster_5_8
	{
		public static double classify(System.Object[] i)
		{
			/* p_84 */
			if (i[84] == null)
			{
				return 0.02384036220765065;
			}
			else if (((System.Double) i[84]) <= 2.5)
			{
				return 0.2709968674401225;
			}
			else
			{
				return - 0.3162289593932547;
			}
		}
	}
	class FacialExpressionMotionBooster_5_9
	{
		public static double classify(System.Object[] i)
		{
			/* p_70 */
			if (i[70] == null)
			{
				return - 0.03470334188974684;
			}
			else if (((System.Double) i[70]) <= 8.5)
			{
				return - 0.155099294307833;
			}
			else
			{
				return 0.6988836989701498;
			}
		}
	}
	class FacialExpressionMotionBooster_5_10
	{
		public static double classify(System.Object[] i)
		{
			/* p_49 */
			if (i[49] == null)
			{
				return 0.02479489132985939;
			}
			else if (((System.Double) i[49]) <= 7.5)
			{
				return 0.1446990087279486;
			}
			else
			{
				return - 0.3824011854689255;
			}
		}
	}
	class FacialExpressionMotionBooster_5_11
	{
		public static double classify(System.Object[] i)
		{
			/* p_33 */
			if (i[33] == null)
			{
				return - 0.005659046258015795;
			}
			else if (((System.Double) i[33]) <= 3.5)
			{
				return - 0.1817764129444032;
			}
			else
			{
				return 0.3393310339211688;
			}
		}
	}
	class FacialExpressionMotionBooster_5_12
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return 0.006828258963196553;
			}
			else if (((System.Double) i[30]) <= 1.5)
			{
				return 0.1755629365040028;
			}
			else
			{
				return - 0.3185523876070302;
			}
		}
	}
	class FacialExpressionMotionBooster_5_13
	{
		public static double classify(System.Object[] i)
		{
			/* p_69 */
			if (i[69] == null)
			{
				return - 0.01923891609930676;
			}
			else if (((System.Double) i[69]) <= 2.5)
			{
				return - 0.188054235853058;
			}
			else
			{
				return 0.1850517490939726;
			}
		}
	}
	class FacialExpressionMotionBooster_5_14
	{
		public static double classify(System.Object[] i)
		{
			/* p_59 */
			if (i[59] == null)
			{
				return 0.006798872410551978;
			}
			else if (((System.Double) i[59]) <= 3.5)
			{
				return 0.1715811059796798;
			}
			else
			{
				return - 0.2470174362616331;
			}
		}
	}
	class FacialExpressionMotionBooster_5_15
	{
		public static double classify(System.Object[] i)
		{
			/* p_72 */
			if (i[72] == null)
			{
				return - 0.005149328392487937;
			}
			else if (((System.Double) i[72]) <= 4.5)
			{
				return - 0.1311137347380159;
			}
			else
			{
				return 0.2796031337255913;
			}
		}
	}
	class FacialExpressionMotionBooster_5_16
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return 0.002054903449370332;
			}
			else if (((System.Double) i[28]) <= 22.5)
			{
				return 0.04054167707456605;
			}
			else
			{
				return - 0.6845013913249027;
			}
		}
	}
	class FacialExpressionMotionBooster_5_17
	{
		public static double classify(System.Object[] i)
		{
			/* p_70 */
			if (i[70] == null)
			{
				return - 0.001122252472337193;
			}
			else if (((System.Double) i[70]) <= 16.5)
			{
				return - 0.04340631232683891;
			}
			else
			{
				return 0.6990357092197743;
			}
		}
	}
	class FacialExpressionMotionBooster_5_18
	{
		public static double classify(System.Object[] i)
		{
			/* p_90 */
			if (i[90] == null)
			{
				return 0.003914681918323583;
			}
			else if (((System.Double) i[90]) <= 1.5)
			{
				return 0.1287495574081232;
			}
			else
			{
				return - 0.2201761931719061;
			}
		}
	}
	class FacialExpressionMotionBooster_5_19
	{
		public static double classify(System.Object[] i)
		{
			/* p_91 */
			if (i[91] == null)
			{
				return 0.009703213191969453;
			}
			else if (((System.Double) i[91]) <= 41.0)
			{
				return 0.003485886701348346;
			}
			else
			{
				return 2.999999999998739;
			}
		}
	}
	class FacialExpressionMotionBooster_5_20
	{
		public static double classify(System.Object[] i)
		{
			/* p_38 */
			if (i[38] == null)
			{
				return - 0.002304102846619597;
			}
			else if (((System.Double) i[38]) <= 1.5)
			{
				return 0.1271276542257237;
			}
			else
			{
				return - 0.1334117400241133;
			}
		}
	}
	class FacialExpressionMotionBooster_5_21
	{
		public static double classify(System.Object[] i)
		{
			/* p_69 */
			if (i[69] == null)
			{
				return 0.002176870474974061;
			}
			else if (((System.Double) i[69]) <= 1.5)
			{
				return - 0.2042350576111587;
			}
			else
			{
				return 0.150274593108735;
			}
		}
	}
	class FacialExpressionMotionBooster_5_22
	{
		public static double classify(System.Object[] i)
		{
			/* p_36 */
			if (i[36] == null)
			{
				return 0.01213544489736615;
			}
			else if (((System.Double) i[36]) <= 2.5)
			{
				return 0.1156880230371781;
			}
			else
			{
				return - 0.1692049956297973;
			}
		}
	}
	class FacialExpressionMotionBooster_5_23
	{
		public static double classify(System.Object[] i)
		{
			/* p_33 */
			if (i[33] == null)
			{
				return - 2.417538765319458e-4;
			}
			else if (((System.Double) i[33]) <= 4.5)
			{
				return - 0.09180953908430545;
			}
			else
			{
				return 0.2582644943420799;
			}
		}
	}
	class FacialExpressionMotionBooster_5_24
	{
		public static double classify(System.Object[] i)
		{
			/* p_28 */
			if (i[28] == null)
			{
				return - 0.009992491163165384;
			}
			else if (((System.Double) i[28]) <= 2.5)
			{
				return 0.07271009129192315;
			}
			else
			{
				return - 0.2761892670082209;
			}
		}
	}
	class FacialExpressionMotionBooster_5_25
	{
		public static double classify(System.Object[] i)
		{
			/* p_9 */
			if (i[9] == null)
			{
				return - 0.00379653407914704;
			}
			else if (((System.Double) i[9]) <= 1.5)
			{
				return - 0.07007445892801229;
			}
			else
			{
				return 0.3261202009031511;
			}
		}
	}
	class FacialExpressionMotionBooster_5_26
	{
		public static double classify(System.Object[] i)
		{
			/* p_30 */
			if (i[30] == null)
			{
				return 0.01622355707214333;
			}
			else if (((System.Double) i[30]) <= 15.5)
			{
				return 0.06729971137559278;
			}
			else
			{
				return - 0.4231174730234251;
			}
		}
	}
	class FacialExpressionMotionBooster_5_27
	{
		public static double classify(System.Object[] i)
		{
			/* p_50 */
			if (i[50] == null)
			{
				return - 0.01146226821801314;
			}
			else if (((System.Double) i[50]) <= 4.5)
			{
				return - 0.05940508106748987;
			}
			else
			{
				return 0.4562738300254408;
			}
		}
	}
	class FacialExpressionMotionBooster_5_28
	{
		public static double classify(System.Object[] i)
		{
			/* p_61 */
			if (i[61] == null)
			{
				return 0.010156226049257;
			}
			else if (((System.Double) i[61]) <= 3.5)
			{
				return 0.1115837089427297;
			}
			else
			{
				return - 0.1744059629020567;
			}
		}
	}
	class FacialExpressionMotionBooster_5_29
	{
		public static double classify(System.Object[] i)
		{
			/* p_80 */
			if (i[80] == null)
			{
				return - 0.001146782037169099;
			}
			else if (((System.Double) i[80]) <= 6.5)
			{
				return - 0.1072833766916298;
			}
			else
			{
				return 0.2305403472703709;
			}
		}
	}
}