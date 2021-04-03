/**
 * ______________________________________________________
 * This file is part of ko-item-tbl-importer project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace ItemTableMerger
{
    public partial class frmMergeTables : Form
    {
        public frmMergeTables()
        {
            InitializeComponent();
        }

        //private byte extCount = 44;

        public void StartMerge()
        {
            Thread thr = new Thread(Merge);
            thr.Start();
            ShowDialog();
        }
        void Merge(object x)
        {
            int p = 0;
            p += StaticReference._tblSet.Tables["item_org_us.tbl"].Rows.Count;
            for (int i = 0; i < StaticReference._tblSet.Tables.Count-1; i++)
            {
               p += StaticReference._tblSet.Tables[string.Format("item_ext_{0}_us.tbl",i)].Rows.Count;  
            }
            pbSTotal.Maximum = p;
            foreach (DataRow baseRow in StaticReference._tblSet.Tables["item_org_us.tbl"].Rows)
            {
                DataRow[] extVariations = StaticReference.GetExtRow(Convert.ToByte(baseRow[1]), Convert.ToInt32(baseRow[0]));
                foreach (DataRow extensionRow in extVariations)
                {
                    if (Convert.ToInt32(extensionRow[2]) != 0)
                    {
                        // Unique check
                        if (Convert.ToInt32(baseRow[0]) != Convert.ToInt32(extensionRow[2]))
                            continue;
                    }
                    // Skip unique
                    if (Convert.ToInt32(extensionRow[2]) == 0 && Convert.ToInt32(baseRow[4]) == 1)
                        continue;
                    // todo = eğer base unique ise, normal variantlarını çıkartma.
                    // todo = item isimlerini düzgün çek.
                    bool isBaseVariation = Convert.ToInt32(extensionRow[2]) == 0;
                    var item = new Item
                    {
                        Num = Convert.ToInt32(baseRow[0])+Convert.ToInt32(extensionRow[0]),
                        strName = string.Format("{0} (+{1})", (isBaseVariation ? Convert.ToString(baseRow[2]) : Convert.ToString(extensionRow[3])), (Convert.ToInt32(baseRow[1]) >24 ? (Convert.ToInt32(extensionRow[0]) % 30 == 0 ? 30:Convert.ToInt32(extensionRow[0]) % 30):(Convert.ToInt32(extensionRow[0]) % 10 == 0 ? 10 :Convert.ToInt32(extensionRow[0]) % 10))),
                        strDesc =  Convert.ToString(baseRow[3]) ,
                        strExtName = Convert.ToString(extensionRow[1]),
                        strExtDesc =isBaseVariation ? Convert.ToString(extensionRow[3]):Convert.ToString(baseRow[2]),
                        Extension = Convert.ToInt32(baseRow[1]),
                        isUnique  = Convert.ToInt32(baseRow[4]),
                        IconID = Convert.ToInt32(extensionRow[6]) == 0 ? Convert.ToInt32(baseRow[6]) : Convert.ToInt32(extensionRow[6]),
                        Class = Convert.ToByte(baseRow[14]),
                        Ac = (short)(Convert.ToInt16(baseRow[22]) + Convert.ToInt16(extensionRow[14])),
                        ItemType = Convert.ToByte(extensionRow[7]),
                        Damage = (short)(Convert.ToInt16(extensionRow[8]) + Convert.ToInt16(baseRow[15])),
                        Range = Convert.ToInt16(baseRow[17]),
                        Delay = Convert.ToInt16(baseRow[16]),
                        Kind = Convert.ToByte(baseRow[10]),
                        Slot = Convert.ToByte(baseRow[12]),
                        SellingGroup = Convert.ToByte(baseRow[35]),
                        BuyPrice = Convert.ToInt32(baseRow[20])* Convert.ToInt32(extensionRow[13]),
                        SellPrice = Convert.ToInt32(baseRow[21]) * Convert.ToInt32(extensionRow[13]),
                        Countable = Convert.ToByte(baseRow[23]),
                        Hitrate = Convert.ToInt16(extensionRow[10]),
                        EvasionRate = Convert.ToInt16(extensionRow[11]),
                        Weight = Convert.ToInt16(baseRow[18]),
                        Duration = (short)(Convert.ToInt16(baseRow[19]) + Convert.ToInt16(extensionRow[12])),
                        Race = Convert.ToByte(baseRow[13]),
                        DaggerAc = Convert.ToInt16(extensionRow[15]),
                        SwordAc = Convert.ToInt16(extensionRow[16]),
                        MaceAc = Convert.ToInt16(extensionRow[17]),
                        AxeAc = Convert.ToInt16(extensionRow[18]),
                        SpearAc = Convert.ToInt16(extensionRow[19]),
                        BowAc = Convert.ToInt16(extensionRow[20]),
                        FireDamage = Convert.ToByte(extensionRow[21]),
                        IceDamage = Convert.ToByte(extensionRow[22]),
                        LightningDamage = Convert.ToByte(extensionRow[23]),
                        PoisonDamage = Convert.ToByte(extensionRow[24]),
                        HPDrain = Convert.ToByte(extensionRow[25]),
                        MPDamage = Convert.ToByte(extensionRow[26]),
                        MPDrain = Convert.ToByte(extensionRow[27]),
                        StrB = Convert.ToInt16(extensionRow[30]),
                        StaB = Convert.ToInt16(extensionRow[31]),
                        DexB = Convert.ToInt16(extensionRow[32]),
                        IntelB = Convert.ToInt16(extensionRow[33]),
                        ChaB = Convert.ToInt16(extensionRow[34]),
                        MaxHpB = Convert.ToInt16(extensionRow[35]),
                        MaxMpB = Convert.ToInt16(extensionRow[36]),
                        FireR = Convert.ToInt16(extensionRow[37]),
                        ColdR = Convert.ToInt16(extensionRow[38]),
                        LightningR = Convert.ToInt16(extensionRow[39]),
                        MagicR = Convert.ToInt16(extensionRow[40]),
                        PoisonR = Convert.ToInt16(extensionRow[41]),
                        CurseR = Convert.ToInt16(extensionRow[42]),
                      
                        Effect1 = Convert.ToInt32(extensionRow[43]),
                        Effect2 = Convert.ToInt32(extensionRow[44]),

                        ReqLevel = (short)(Convert.ToInt16(extensionRow[45]) + Convert.ToInt16(baseRow[26])),
                        ReqLevelMax =(byte)(Convert.ToInt16(baseRow[27])),
                        ReqRank = Convert.ToInt16(extensionRow[46]),
                        ReqTitle = Convert.ToInt16(extensionRow[47]),
                        ReqStr = (short)(Convert.ToInt16(extensionRow[48]) + Convert.ToInt16(baseRow[30])),
                        ReqSta = (short)(Convert.ToInt16(extensionRow[49]) + Convert.ToInt16(baseRow[31])),
                        ReqDex = (short)(Convert.ToInt16(extensionRow[50]) + Convert.ToInt16(baseRow[32])),
                        
                        ReqCha = (short)(Convert.ToInt16(extensionRow[52]) + Convert.ToInt16(baseRow[34])),
                        ItemGrade = Convert.ToByte(baseRow[36])


                    };

                    if (item.Kind == 230)
                        item.ReqIntel = (short) (Convert.ToInt16(extensionRow[51]));
                    else
                        item.ReqIntel = (short) (Convert.ToInt16(extensionRow[51]) + Convert.ToInt16(baseRow[33]));
                    
                    StaticReference.MergedTable.Add(item);
                    pbSTotal.PerformStep();
                }
            }
            Close();
        }

        private void frmMergeTables_Load(object sender, EventArgs e)
        {

        }
    }
}
