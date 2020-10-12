using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA2_new
{
    public partial class Form1 : Form
    {
         MaTran matran = new MaTran();
         List<string> mien = new List<string>();
         List<int> dienTich = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           KhoiTaoMaTran();

        }

        void KhoiTaoMaTran(int soDinh = 1)
        {
            matran = new MaTran();
            matran.A = null;
            matran.TaoMaTran(soDinh, soDinh);
            matran.ShowMaTran();
            matran.Location = new Point(0, 0);
            panelShowmatran.Controls.Add(matran);
            matran.Visible = true;
        }

        private void btnShowMaTran_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = ".txt|*.txt";
            open.ShowDialog();
            matran.DocMatTranTuFile(open.FileName);
            matran.ShowMaTran();

         //   MessageBox.Show(matran.A[5-1,2-1].ToString());

        }

        /*string Mien;
        string DT;

        void DuyetMien(object sender, EventArgs e)
        {
            for (int i = 0; i < matran.SoDong; i++)
            {
                for (int j = 0; j < matran.SoCot; j++)
                {
                    if(matran.A[i,j] == matran.A[1,1])
                    {
                        Mien += 1;
                        DT += 1;
                    }
                }
            }
            
        }*/

        public void DuyetMien()
        {
            // Khai bao bien
            string[,] B = new string[matran.SoDong, matran.SoCot];
            int dong = 1, cot = 1;
            
            // XULY THUAT TOAN
            while (dong <= matran.SoDong)
            {
                if (dong == 1)
                {
                    // Dong dau tien
                    if (cot == 1)
                    {
                        // O dau tien (1,1)
                        mien.Add("(1,1)");
                        dienTich.Add(1);
                        B[dong - 1, cot - 1] = "(1,1)";
                        // Tang so cot len
                        cot++;
                    }
                    else
                    {
                        // Cot thu 2 sang phai
                        if (cot <= matran.SoCot)
                        {
                            if (matran.A[dong - 1, cot - 1] == matran.A[dong - 1, cot - 2])
                            {
                                // O dang xet == O ben trai
                                B[dong - 1, cot - 1] = B[dong - 1, cot - 2];
                                dienTich[mien.IndexOf(B[dong - 1, cot - 1])]++;
                                cot++;
                            }
                            else
                            {
                                // O dang xet != O ben trai
                                B[dong - 1, cot - 1] = "(" + dong + "," + cot + ")";
                                mien.Add("(" + dong + "," + cot + ")");
                                dienTich.Add(1);
                                cot++;
                            }
                        }
                        else
                        {
                            // Cot cuoi cung, tang so dong, reset cot=1
                            cot = 1;
                            dong++;
                        }
                    }
                }
                else
                { 
                    // Dong thu 2 tro len
                    if (cot == 1)
                    {
                        // cot dau tien (n,1)
                        if (matran.A[dong - 1, cot - 1] == matran.A[dong - 2, cot - 1])
                        {
                            // O dang xet == O phia tren
                            B[dong - 1, cot - 1] = B[dong - 2, cot - 1];
                            dienTich[mien.IndexOf(B[dong - 1, cot - 1])]++;
                        }
                        else
                        {
                            // O dang xet != O phia tren
                            B[dong-1,cot-1] = "("+dong+","+cot+")";
                            mien.Add("(" + dong + "," + cot + ")");
                            dienTich.Add(1);
                        }
                        cot++;
                    }
                    else
                    {
                        // Cot thu 2 sang phai
                        if (cot <= matran.SoCot)
                        {
                            if (matran.A[dong - 1, cot - 1] != matran.A[dong - 2, cot - 1] && matran.A[dong - 1, cot - 1] != matran.A[dong - 1, cot - 2])
                            {
                                // Otren != Odangxet && Otrai != Odangxet
                                // Mien moi
                                B[dong - 1, cot - 1] = "(" + dong + "," + cot + ")";
                                mien.Add("(" + dong + "," + cot + ")");
                                dienTich.Add(1);
                            }
                            else
                            {
                                // Mien cu
                                if (matran.A[dong - 1, cot - 1] == matran.A[dong - 1, cot - 2] && matran.A[dong - 1, cot - 1] == matran.A[dong - 2, cot - 1])
                                {
                                    // Ba o bang nhau
                                    B[dong - 1, cot - 1] = B[dong - 2, cot - 1];
                                    dienTich[mien.IndexOf(B[dong - 1, cot - 1])]++;
                                    if (B[dong - 1, cot - 2] != B[dong - 1, cot - 1])
                                    {
                                        // O tren va O trai khac mien
                                        // Cap nhat mien
                                        dienTich[mien.IndexOf(B[dong - 1, cot - 1])] += dienTich[mien.IndexOf(B[dong - 1, cot - 2])];
                                        // Xoa mien tam (mien sai)
                                        dienTich.RemoveAt(mien.IndexOf(B[dong - 1, cot - 2]));
                                        mien.RemoveAt(mien.IndexOf(B[dong - 1, cot - 2]));
                                        // Cap nhat ma tran mien (matran B)
                                        B[dong - 1, cot - 2] = B[dong - 2, cot - 1];
                                    }
                                }
                                else
                                {
                                    if (matran.A[dong - 1, cot - 1] == matran.A[dong - 1, cot - 2])
                                    {
                                        // Neu ben trai bang
                                        B[dong - 1, cot - 1] = B[dong - 1, cot - 2];
                                        dienTich[mien.IndexOf(B[dong - 1, cot - 1])]++;
                                    }
                                    else
                                    {
                                        // Neu ben tren bang
                                        B[dong - 1, cot - 1] = B[dong - 2, cot - 1];
                                        dienTich[mien.IndexOf(B[dong - 1, cot - 1])]++;
                                    }
                                }
                            }
                            cot++;
                        }
                        else
                        {
                            cot = 1;
                            dong++;
                        }
                    }
                }
            } // End of while
        }

        public int TongSoMien()
        {
            return mien.Count;
        }

        public int getDienTich(string TenMien)
        {
            return dienTich.ElementAt<int>(mien.IndexOf(TenMien));
        }

        public string getMienMax()
        {
            int max = dienTich[0];
            for (int i = 0; i < dienTich.Count; i++)
            {
                if (dienTich[i] > max)
                {
                    max = dienTich[i];
                }
            }
            return mien.ElementAt(dienTich.IndexOf(max));
        }

        public string getMienMin()
        {
            int min = dienTich[0];
            for (int i = 0; i < dienTich.Count; i++)
            {
                if (dienTich[i] < min)
                {
                    min = dienTich[i];
                }
            }
            return mien.ElementAt(dienTich.IndexOf(min));
        }

        private void btnLuuMT_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Document|*.txt|All file|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                matran.GhiMaTranVaoFile(save.FileName);
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
        }

        private void btnDuyetMien_Click(object sender, EventArgs e)
        {
            DuyetMien();
            MessageBox.Show("Tong so mien: "+TongSoMien());
            MessageBox.Show("Mien lon nhat: " + getMienMax() + "\nDien tich: " + getDienTich(getMienMax()));
            MessageBox.Show("Mien nho nhat: " + getMienMin() + "\nDien tich: " + getDienTich(getMienMin()));
        }

    }
}
