﻿// Copyright (C) HYMMA All rights reserved.
// Licensed under the MIT license

#region License

//Preamble

//This License governs Your use of the Work. This License is intended to allow developers to use the Source Code and Executable Files provided as part of the Work in any application in any form.

//The main points subject to the terms of the License are:

//    Source Code and Executable Files can be used in commercial applications;
//Source Code and Executable Files can be redistributed; and
//Source Code can be modified to create derivative works.
//    No claim of suitability, guarantee, or any warranty whatsoever is provided. The software is provided "as-is".
//    The Article(s) accompanying the Work may not be distributed or republished without the Author's consent

//This License is entered between You, the individual or other entity reading or otherwise making use of the Work licensed pursuant to this License and the individual or other entity which offers the Work under the terms of this License ("Author").
//License

//THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CODE PROJECT OPEN LICENSE ("LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS PROHIBITED.

//BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HEREIN, YOU ACCEPT AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. THE AUTHOR GRANTS YOU THE RIGHTS CONTAINED HEREIN IN CONSIDERATION OF YOUR ACCEPTANCE OF SUCH TERMS AND CONDITIONS. IF YOU DO NOT AGREE TO ACCEPT AND BE BOUND BY THE TERMS OF THIS LICENSE, YOU CANNOT MAKE ANY USE OF THE WORK.

//    Definitions.
//        "Articles" means, collectively, all articles written by Author which describes how the Source Code and Executable Files for the Work may be used by a user.
//        "Author" means the individual or entity that offers the Work under the terms of this License.
//        "Derivative Work" means a work based upon the Work or upon the Work and other pre-existing works.
//        "Executable Files" refer to the executables, binary files, configuration and any required data files included in the Work.
//        "Publisher" means the provider of the website, magazine, CD-ROM, DVD or other medium from or by which the Work is obtained by You.
//        "Source Code" refers to the collection of source code and configuration files used to create the Executable Files.
//        "Standard Version" refers to such a Work if it has not been modified, or has been modified in accordance with the consent of the Author, such consent being in the full discretion of the Author.
//        "Work" refers to the collection of files distributed by the Publisher, including the Source Code, Executable Files, binaries, data files, documentation, whitepapers and the Articles.
//        "You" is you, an individual or entity wishing to use the Work and exercise your rights under this License.
//    Fair Use/Fair Use Rights. Nothing in this License is intended to reduce, limit, or restrict any rights arising from fair use, fair dealing, first sale or other limitations on the exclusive rights of the copyright owner under copyright law or other applicable laws.
//    License Grant. Subject to the terms and conditions of this License, the Author hereby grants You a worldwide, royalty-free, non-exclusive, perpetual (for the duration of the applicable copyright) license to exercise the rights in the Work as stated below:
//        You may use the standard version of the Source Code or Executable Files in Your own applications.
//        You may apply bug fixes, portability fixes and other modifications obtained from the Public Domain or from the Author. A Work modified in such a way shall still be considered the standard version and will be subject to this License.
//        You may otherwise modify Your copy of this Work (excluding the Articles) in any way to create a Derivative Work, provided that You insert a prominent notice in each changed file stating how, when and where You changed that file.
//        You may distribute the standard version of the Executable Files and Source Code or Derivative Work in aggregate with other (possibly commercial) programs as part of a larger (possibly commercial) software distribution.
//        The Articles discussing the Work published in any form by the author may not be distributed or republished without the Author's consent. The author retains copyright to any such Articles. You may use the Executable Files and Source Code pursuant to this License but you may not repost or republish or otherwise distribute or make available the Articles, without the prior written consent of the Author.
//    Any subroutines or modules supplied by You and linked into the Source Code or Executable Files of this Work shall not be considered part of this Work and will not be subject to the terms of this License.
//    Patent License. Subject to the terms and conditions of this License, each Author hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, import, and otherwise transfer the Work.
//    Restrictions. The license granted in Section 3 above is expressly made subject to and limited by the following restrictions:
//        You agree not to remove any of the original copyright, patent, trademark, and attribution notices and associated disclaimers that may appear in the Source Code or Executable Files.
//        You agree not to advertise or in any way imply that this Work is a product of Your own.
//        The name of the Author may not be used to endorse or promote products derived from the Work without the prior written consent of the Author.
//        You agree not to sell, lease, or rent any part of the Work. This does not restrict you from including the Work or any part of the Work inside a larger software distribution that itself is being sold. The Work by itself, though, cannot be sold, leased or rented.
//        You may distribute the Executable Files and Source Code only under the terms of this License, and You must include a copy of, or the Uniform Resource Identifier for, this License with every copy of the Executable Files or Source Code You distribute and ensure that anyone receiving such Executable Files and Source Code agrees that the terms of this License apply to such Executable Files and/or Source Code. You may not offer or impose any terms on the Work that alter or restrict the terms of this License or the recipients' exercise of the rights granted hereunder. You may not sublicense the Work. You must keep intact all notices that refer to this License and to the disclaimer of warranties. You may not distribute the Executable Files or Source Code with any technological measures that control access or use of the Work in a manner inconsistent with the terms of this License.
//        You agree not to use the Work for illegal, immoral or improper purposes, or on pages containing illegal, immoral or improper material. The Work is subject to applicable export laws. You agree to comply with all such laws and regulations that may apply to the Work after Your receipt of the Work.
//    Representations, Warranties and Disclaimer. THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU, THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT, PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY, MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES. YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR DERIVATIVE WORKS.
//    Indemnity. You agree to defend, indemnify and hold harmless the Author and the Publisher from and against any claims, suits, losses, damages, liabilities, costs, and expenses (including reasonable legal or attorneys’ fees) resulting from or relating to any use of the Work by You.
//    Limitation on Liability. EXCEPT TO THE EXTENT REQUIRED BY APPLICABLE LAW, IN NO EVENT WILL THE AUTHOR OR THE PUBLISHER BE LIABLE TO YOU ON ANY LEGAL THEORY FOR ANY SPECIAL, INCIDENTAL, CONSEQUENTIAL, PUNITIVE OR EXEMPLARY DAMAGES ARISING OUT OF THIS LICENSE OR THE USE OF THE WORK OR OTHERWISE, EVEN IF THE AUTHOR OR THE PUBLISHER HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.
//    Termination.
//        This License and the rights granted hereunder will terminate automatically upon any breach by You of any term of this License. Individuals or entities who have received Derivative Works from You under this License, however, will not have their licenses terminated provided such individuals or entities remain in full compliance with those licenses. Sections 1, 2, 6, 7, 8, 9, 10 and 11 will survive any termination of this License.
//        If You bring a copyright, trademark, patent or any other infringement claim against any contributor over infringements You claim are made by the Work, your License from such contributor to the Work ends automatically.
//        Subject to the above terms and conditions, this License is perpetual (for the duration of the applicable copyright in the Work). Notwithstanding the above, the Author reserves the right to release the Work under different license terms or to stop distributing the Work at any time; provided, however that any such election will not serve to withdraw this License (or any other license that has been, or is required to be, granted under the terms of this License), and this License will continue in full force and effect unless terminated as stated above.
//    Publisher.The parties hereby confirm that the Publisher shall not, under any circumstances, be responsible for and shall not have any liability in respect of the subject matter of this License.The Publisher makes no warranty whatsoever in connection with the Work and shall not be liable to You or any party on any legal theory for any damages whatsoever, including without limitation any general, special, incidental or consequential damages arising in connection to this license.The Publisher reserves the right to cease making the Work available to You at any time without notice
//    Miscellaneous
//        This License shall be governed by the laws of the location of the head office of the Author or if the Author is an individual, the laws of location of the principal place of residence of the Author.
//        If any provision of this License is invalid or unenforceable under applicable law, it shall not affect the validity or enforceability of the remainder of the terms of this License, and without further action by the parties to this License, such provision shall be reformed to the minimum extent necessary to make such provision valid and enforceable.
//        No term or provision of this License shall be deemed waived and no breach consented to unless such waiver or consent shall be in writing and signed by the party to be charged with such waiver or consent.
//        This License constitutes the entire agreement between the parties with respect to the Work licensed herein. There are no understandings, agreements or representations with respect to the Work not specified herein.The Author shall not be bound by any additional provisions that may appear in any communication from You. This License may not be modified without the mutual written agreement of the Author and You.


#endregion

//All the creadit goes to Pierre poliakoff
//https://www.codeproject.com/script/Membership/View.aspx?mid=1072728

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Hymma.Solidworks.Addins
{
    /// <summary>
    /// adds an alpha layer to a bitmap file
    /// </summary>
    public sealed class MaskedBitmap
    {
        /// <summary>
        /// coverts and saves a bitmap to specified location
        /// </summary>
        /// <param name="image">file to get bitmask for</param>
        /// <param name="size">new size for the new png file</param>
        /// <param name="fullFileName">file name with or without extension, this method will save the image as .png file format only</param>
        /// <param name="allowPartialOpacity">if set true the number assigned to "opacityThreshold" will be considered as entered</param>
        /// <param name="opacityThreshold">a number between 0 and 255 maximum</param>
        /// <param name="invertedMask"></param>
        public static void SaveAsPng(Bitmap image, Size size, ref string fullFileName, bool allowPartialOpacity = true, byte opacityThreshold = 255, bool invertedMask = true)
        {
            //check for valid file name . . .
            if (string.IsNullOrEmpty(fullFileName))
                throw new ArgumentNullException("filename assigned to icon was empty");

            //if the string provided does not have .png ...
            if (!fullFileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))

                //add the extension to the file name
                fullFileName += ".png";

            //get maskImage
            if (!File.Exists(fullFileName))
            {
                using (image)
                {

                    Bitmap maskImage;

                    //if type of image provided is png we simply save it without processing it
                    if (image.RawFormat.Equals(ImageFormat.Png))
                    {
                        maskImage = image;
                    }
                    else
                    {
                        maskImage = GetMaskedImage(image, allowPartialOpacity, opacityThreshold, invertedMask);
                    }

                    using (maskImage)
                    {
                        var newSize = new Bitmap(maskImage, size);
                        using (newSize)
                        {
                            newSize.Save(fullFileName, ImageFormat.Png);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// get the maske for a bitmap
        /// </summary>
        /// <param name="original"></param>
        /// <param name="allowPartialOpacity">if set true the number assigned to "opacityThreshold" will be considered as entered</param>
        /// <param name="opacityThreshold">a number between 0 and 255 maximum</param>
        /// <param name="invertedMask"></param>
        /// <returns></returns>
        public static Bitmap GetImageMask(Bitmap original, bool allowPartialOpacity = true, byte opacityThreshold = 255, bool invertedMask = true)
        {
            var maskImage = Create32bppImageAndClearAlpha(original);

            BitmapData bmpData = maskImage.LockBits(new Rectangle(0, 0, maskImage.Width, maskImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, maskImage.PixelFormat);

            byte[] maskImageRGBData = new byte[bmpData.Stride * bmpData.Height];

            Marshal.Copy(bmpData.Scan0, maskImageRGBData, 0, maskImageRGBData.Length);

            byte greyLevel;
            for (int i = 0; i + 2 < maskImageRGBData.Length; i += 4)
            {
                //convert to gray scale R:0.30 G=0.59 B 0.11
                greyLevel = (byte)(0.3 * maskImageRGBData[i + 2] + 0.59 * maskImageRGBData[i + 1] + 0.11 * maskImageRGBData[i]);

                if (!allowPartialOpacity)
                {
                    greyLevel = (greyLevel < opacityThreshold) ? byte.MinValue : byte.MaxValue;
                }
                if (invertedMask)
                {
                    greyLevel = (byte)(255 - greyLevel);
                }

                maskImageRGBData[i] = greyLevel;
                maskImageRGBData[i + 1] = greyLevel;
                maskImageRGBData[i + 2] = greyLevel;
            }
            Marshal.Copy(maskImageRGBData, 0, bmpData.Scan0, maskImageRGBData.Length);
            maskImage.UnlockBits(bmpData);
            return maskImage;
        }

        /// <summary>
        /// converts the bitmap to another that supports alpha channel and then applies transparency level provided to that channel in the image. basically makes an image transparent 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="allowPartialOpacity"></param>
        /// <param name="opacityThreshold"></param>
        /// <param name="invertedMask"></param>
        /// <returns></returns>
        public static Bitmap GetMaskedImage(Bitmap original, bool allowPartialOpacity = false, byte opacityThreshold = 255, bool invertedMask = true)
        {
            if (original == null)
                throw new ArgumentNullException(nameof(original));
            var maskImage = GetImageMask(original, allowPartialOpacity, opacityThreshold, invertedMask);
            if (original.Width != maskImage.Width || original.Height != maskImage.Height)
            {
                throw new ArgumentOutOfRangeException("Error: mask and image must have the same size");
            }
            else
            {
                //allocate the Masked image in ARGB format
                var maskedImage = Create32bppImageAndClearAlpha(original);

                BitmapData bmpData1 = maskedImage.LockBits(new Rectangle(0, 0, maskedImage.Width, maskedImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, maskedImage.PixelFormat);
                byte[] maskedImageRGBAData = new byte[bmpData1.Stride * bmpData1.Height];
                Marshal.Copy(bmpData1.Scan0, maskedImageRGBAData, 0, maskedImageRGBAData.Length);

                BitmapData bmpData2 = maskImage.LockBits(new Rectangle(0, 0, maskImage.Width, maskImage.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, maskImage.PixelFormat);
                byte[] maskImageRGBAData = new byte[bmpData2.Stride * bmpData2.Height];
                Marshal.Copy(bmpData2.Scan0, maskImageRGBAData, 0, maskImageRGBAData.Length);

                //copy the mask to the Alpha layer
                for (int i = 0; i + 2 < maskedImageRGBAData.Length; i += 4)
                {
                    maskedImageRGBAData[i + 3] = maskImageRGBAData[i];

                }
                Marshal.Copy(maskedImageRGBAData, 0, bmpData1.Scan0, maskedImageRGBAData.Length);
                maskedImage.UnlockBits(bmpData1);
                maskImage.UnlockBits(bmpData2);
                return maskedImage;
            }
        }

        //converts a 24bpp bitmap to another that supports alpha layer whith 32bpp 
        private static Bitmap Create32bppImageAndClearAlpha(Bitmap tmpImage)
        {
            // declare the new image that will be returned by the function
            Bitmap returnedImage = new Bitmap(tmpImage.Width, tmpImage.Height, PixelFormat.Format32bppArgb);

            // create a graphics instance to draw the original image in the new one
            Rectangle rect = new Rectangle(0, 0, tmpImage.Width, tmpImage.Height);
            Graphics g = Graphics.FromImage(returnedImage);

            // create an image attribe to force a clearing of the alpha layer
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = {
                        new float[] {1,0,0,0,0},
                        new float[] {0,1,0,0,0},
                        new float[] {0,0,1,0,0},
                        new float[] {0,0,0,0,0},
                        new float[] {0,0,0,1,1}};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // draw the original image 
            g.DrawImage(tmpImage, rect, 0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            return returnedImage;
        }
    }
}
