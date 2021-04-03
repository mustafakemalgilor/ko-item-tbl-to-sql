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
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace ItemTableMerger
{


    public partial class mainFrm : Form
    {

        #region Declaration

        class InsertIntoQuery
        {
            private StringBuilder _storage = new StringBuilder();
            private readonly string _tblName;
            private readonly IList<string> _columnNames; 
            public InsertIntoQuery(string tableName)
            {
                _storage.Append(string.Format("INSERT INTO {0} VALUES(", tableName));
                _tblName = tableName;
            }

            public InsertIntoQuery(string tableName, IList<string> columnNames)
            {
                _storage.Append(string.Format("INSERT INTO {0} (", tableName));
                for (var i = 0; i < columnNames.Count; i++)
                {
                    _storage.Append(i == columnNames.Count - 1
                        ? string.Format("{0}) VALUES(", columnNames[i])
                        : string.Format("{0},", columnNames[i]));
                }

                _tblName = tableName;
                _columnNames = columnNames;
            }
            public void AppendValue(string value)
            {
                _storage.Append(string.Format("{0},", value));
            }
            public void AppendString(string value)
            {
                _storage.Append(string.Format("'{0}',", value));
            }
            public void AppendEndValue(string value)
            {
                _storage.Append(string.Format("{0}", value));
            }

            public string GetQuery()
            {
                return _storage.ToString() + ")";
                
            }
            public void Clear()
            {
                _storage = new StringBuilder();
                if (_columnNames.Count > 0)
                {
                    _storage.Append(string.Format("INSERT INTO {0} (", _tblName));
                    for (var i = 0; i < _columnNames.Count; i++)
                    {
                        _storage.Append(i == _columnNames.Count - 1
                            ? string.Format("{0}) VALUES(", _columnNames[i])
                            : string.Format("{0},", _columnNames[i]));
                    }
                }
                else
                {
                    _storage.Append(string.Format("INSERT INTO {0} VALUES(", _tblName)); 
                }
               
            }
        }

        private readonly DataTable ITEM = new DataTable("ITEM");

        private readonly Type[] columnTypes =
        {
            typeof (string),
            typeof (string),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (long),
            typeof (long),
            typeof (short),
            typeof (byte),
            typeof (int),
            typeof (int),
            typeof (short),
            typeof (byte),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (byte),
            typeof (byte),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (byte),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (short),
            typeof (int),
        };

        private readonly string[] columnNames = new[]
        {
            "strName",
            "strDesc",
            "Kind",
            "Slot",
            "Race",
            "Class",
            "Damage",
            "Delay",
            "Range",
            "Weight",
            "Duration",
            "BuyPrice",
            "SellPrice",
            "Ac",
            "Countable",
            "Effect1",
            "Effect2",
            "ReqLevel",
            "ReqLevelMax",
            "ReqRank",
            "ReqTitle",
            "ReqStr",
            "ReqSta",
            "ReqDex",
            "ReqIntel",
            "ReqCha",
            "SellingGroup",
            "ItemType",
            "Hitrate",
            "EvasionRate",
            "DaggerAc",
            "SwordAc",
            "MaceAc",
            "AxeAc",
            "SpearAc",
            "BowAc",
            "FireDamage",
            "IceDamage",
            "LightningDamage",
            "PoisonDamage",
            "HPDrain",
            "MPDamage",
            "MPDrain",
            "MirrorDamage",
            "Droprate",
            "StrB",
            "StaB",
            "DexB",
            "IntelB",
            "ChaB",
            "MaxHpB",
            "MaxMpB",
            "FireR",
            "ColdR",
            "LightningR",
            "MagicR",
            "PoisonR",
            "CurseR",
            "IconID"
        };

#endregion

        public mainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading tables..";
            using (var tbl = new frmLoadTables())
            {
                tbl.vLoad();
                btnExportAsSQL.Enabled = true;
            }
            lblStatus.Text = "Table loading done, merging tables..";

            using (frmMergeTables mrg = new frmMergeTables())
            {
                mrg.StartMerge();
            }
            groupBox2.Enabled = true;
            lblStatus.Text = "Merging done. Select an export option.";
            btnLoadAndMerge.Enabled = false;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }

      



        public void Merge()
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                ITEM.Columns.Add(new DataColumn(columnNames[i], columnTypes[i]));
            }

            foreach (Item i in StaticReference.MergedTable)
            {
                ITEM.Rows.Add
                    (i.strName,
                        i.strDesc,
                        i.Kind,
                        i.Slot,
                        i.Race,
                        i.Class,
                        i.Damage,
                        i.Delay,
                        i.Range,
                        i.Weight,
                        i.Duration,
                        i.BuyPrice,
                        i.SellPrice,
                        i.Ac,
                        i.Countable,
                        i.Effect1,
                        i.Effect2,
                        i.ReqLevel,
                        i.ReqLevelMax,
                        i.ReqRank,
                        i.ReqTitle,
                        i.ReqStr,
                        i.ReqSta,
                        i.ReqDex,
                        i.ReqIntel,
                        i.ReqCha,
                        i.SellingGroup,
                        i.ItemType,
                        i.Hitrate,
                        i.EvasionRate,
                        i.DaggerAc,
                        i.SwordAc,
                        i.MaceAc,
                        i.AxeAc,
                        i.SpearAc,
                        i.BowAc,
                        i.FireDamage,
                        i.IceDamage,
                        i.LightningDamage,
                        i.PoisonDamage,
                        i.HPDrain,
                        i.MPDamage,
                        i.MPDrain,
                        i.MirrorDamage,
                        i.Droprate,
                        i.StrB,
                        i.StaB,
                        i.DexB,
                        i.IntelB,
                        i.ChaB,
                        i.MaxHpB,
                        i.MaxMpB,
                        i.FireR,
                        i.ColdR,
                        i.LightningR,
                        i.MagicR,
                        i.PoisonR,
                        i.CurseR,
                        i.IconID
                    );
            }

        }


        private void button1_Click_3(object sender, EventArgs e)
        {
            Merge();
        }

        private void ExportAsSQL()
        {
            string folder = $".\\SQLEXPORT-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}\\";
            Directory.CreateDirectory(folder);
            int index = 0;
            List<string> columnNames = new List<string>()
            {
                "Num",
                "strName",
                "strExtensionName",
                "strDescription",
                "strExtensionDescription",
                "Extension",
                "isUnique",
                "IconID",
                "Kind",
                "Slot",
                "Race",
                "Class",
                "Damage",
                "Delay",
                "Range",
                "Weight",
                "Duration",
                "BuyPrice",
                "SellPrice",
                "Ac",
                "Countable",
                "Effect1",
                "Effect2",
                "ReqLevel",
                "ReqLevelMax",
                "ReqRank",
                "ReqTitle",
                "ReqStr",
                "ReqSta",
                "ReqDex",
                "ReqIntel",
                "ReqCha",
                "SellingGroup",
                "ItemType",
                "Hitrate",
                "EvasionRate",
                "DaggerAc",
                "SwordAc",
                "MaceAc",
                "AxeAc",
                "SpearAc",
                "BowAc",
                "FireDamage",
                "IceDamage",
                "LightningDamage",
                "PoisonDamage",
                "HPDrain",
                "MPDamage",
                "MPDrain",
                "MirrorDamage",
                "Droprate",
                "StrB",
                "StaB",
                "DexB",
                "IntelB",
                "ChaB",
                "MaxHpB",
                "MaxMpB",
                "FireR",
                "ColdR",
                "LightningR",
                "MagicR",
                "PoisonR",
                "CurseR",
                "ItemGrade"
            };
            var iiQuery = new InsertIntoQuery("ITEM", columnNames);
         
                List<string> qry = new List<string>();
            foreach (Item i in StaticReference.MergedTable)
            {
               
                iiQuery.AppendValue(i.Num.ToString());
                iiQuery.AppendString(i.strName.Replace("'","_"));
                iiQuery.AppendString(i.strExtName.Replace("'", "_"));
                iiQuery.AppendString(i.strDesc.Replace("'", "_"));
                iiQuery.AppendString(i.strExtDesc.Replace("'", "_"));
                iiQuery.AppendValue(i.Extension.ToString());
                iiQuery.AppendValue(i.isUnique.ToString());
                iiQuery.AppendValue(i.IconID.ToString());
                iiQuery.AppendValue(i.Kind.ToString( ));
                iiQuery.AppendValue(i.Slot.ToString());
                iiQuery.AppendValue(i.Race.ToString());
                iiQuery.AppendValue(i.Class.ToString());
                iiQuery.AppendValue(i.Damage.ToString());
                iiQuery.AppendValue(i.Delay.ToString());
                iiQuery.AppendValue(i.Range.ToString());
                iiQuery.AppendValue(i.Weight.ToString());
                iiQuery.AppendValue(i.Duration.ToString());
                iiQuery.AppendValue(i.BuyPrice.ToString());
                iiQuery.AppendValue(i.SellPrice.ToString());
                iiQuery.AppendValue(i.Ac.ToString());
                iiQuery.AppendValue(i.Countable.ToString());
                iiQuery.AppendValue(i.Effect1.ToString());
                iiQuery.AppendValue(i.Effect2.ToString());
                iiQuery.AppendValue(i.ReqLevel < 0 ? 0.ToString() : i.ReqLevel.ToString());
                iiQuery.AppendValue(i.ReqLevelMax < 0 ? 0.ToString() : i.ReqLevelMax.ToString());
                iiQuery.AppendValue(i.ReqRank < 0 ? 0.ToString() : i.ReqRank.ToString());
                iiQuery.AppendValue(i.ReqTitle < 0 ? 0.ToString() : i.ReqTitle.ToString());
                iiQuery.AppendValue(i.ReqStr < 0 ? 0.ToString() : i.ReqStr.ToString());
                iiQuery.AppendValue(i.ReqSta < 0 ? 0.ToString() : i.ReqSta.ToString());
                iiQuery.AppendValue(i.ReqDex < 0 ? 0.ToString() : i.ReqDex.ToString());
                iiQuery.AppendValue(i.ReqIntel < 0 ? 0.ToString() : i.ReqIntel.ToString());
                iiQuery.AppendValue(i.ReqCha < 0 ? 0.ToString() : i.ReqCha.ToString());
                iiQuery.AppendValue(i.SellingGroup.ToString());
                iiQuery.AppendValue(i.ItemType.ToString());
                iiQuery.AppendValue(i.Hitrate.ToString());
                iiQuery.AppendValue(i.EvasionRate.ToString());
                iiQuery.AppendValue(i.DaggerAc.ToString());
                iiQuery.AppendValue(i.SwordAc.ToString());
                iiQuery.AppendValue(i.MaceAc.ToString());
                iiQuery.AppendValue(i.AxeAc.ToString());
                iiQuery.AppendValue(i.SpearAc.ToString());
                iiQuery.AppendValue(i.BowAc.ToString());
                iiQuery.AppendValue(i.FireDamage.ToString());
                iiQuery.AppendValue(i.IceDamage.ToString());
                iiQuery.AppendValue(i.LightningDamage.ToString());
                iiQuery.AppendValue(i.PoisonDamage.ToString());
                iiQuery.AppendValue(i.HPDrain.ToString());
                iiQuery.AppendValue(i.MPDamage.ToString());
                iiQuery.AppendValue(i.MPDrain.ToString());
                iiQuery.AppendValue(i.MirrorDamage.ToString());
                iiQuery.AppendValue(i.Droprate.ToString());
                iiQuery.AppendValue(i.StrB.ToString());
                iiQuery.AppendValue(i.StaB.ToString());
                iiQuery.AppendValue(i.DexB.ToString());
                iiQuery.AppendValue(i.IntelB.ToString());
                iiQuery.AppendValue(i.ChaB.ToString());
                iiQuery.AppendValue(i.MaxHpB.ToString());
                iiQuery.AppendValue(i.MaxMpB.ToString());
                iiQuery.AppendValue(i.FireR.ToString());
                iiQuery.AppendValue(i.ColdR.ToString());
                iiQuery.AppendValue(i.LightningR.ToString());
                iiQuery.AppendValue(i.MagicR.ToString());
                iiQuery.AppendValue(i.PoisonR.ToString());
                iiQuery.AppendValue(i.CurseR.ToString());
                iiQuery.AppendEndValue(i.ItemGrade.ToString());
                qry.Add(iiQuery.GetQuery());
                iiQuery.Clear();
                if (qry.Count == 10000)
                {
                    File.WriteAllLines(string.Format(folder + "ITEM_{0}.SQL",index++), qry);
                    qry.Clear();
                }
            }
            // last
            File.WriteAllLines(string.Format(folder + "ITEM_{0}.SQL", index++), qry);
        }

        private void btnExportAsSQL_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Exporting as SQL script..";
            ExportAsSQL();
            lblStatus.Text = "SQL Scripts exported.";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (var fs = new FileStream("itemicon.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None)
                )
            {
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(StaticReference.MergedTable.Count);
                    foreach (Item i in StaticReference.MergedTable)
                    {
                        bw.Write((UInt32) i.Num);
                        bw.Write((UInt32) i.IconID);
                    }
                }
            }
           
                
            
        }


    }
}
