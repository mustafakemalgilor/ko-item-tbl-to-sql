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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ItemTableMerger
{
    class StaticReference
    {
        public static readonly DataSet _tblSet = new DataSet();
        private const string DataPath = @"./Data/";


        public static bool LoadTable(string fname)
        {
            bool anyError = false;
            
            if (File.Exists(DataPath + fname))
            {
                LoadByteDataIntoView(LoadAndDecodeFile(DataPath + fname), fname);
                Trace.TraceInformation(fname + " loaded");
            }
            else
            {
                anyError = true;
            }

        
            return anyError;
        }

        
        private static byte[] LoadAndDecodeFile(string fileName)
        {
            var EncDec = new EncryptionKOStandard();

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                int offset = 0;
                var buffer = new byte[stream.Length];
                while (offset < stream.Length)
                {
                    offset += stream.Read(buffer, offset, ((int) stream.Length) - offset);
                }
                stream.Close();
                EncDec.Decode(ref buffer);
                return buffer;
            }
        }


        private static void LoadByteDataIntoView(byte[] fileData, string Name)
        {
            int startIndex = 0;
            int num2 = BitConverter.ToInt32(fileData, startIndex);
            string tablename = Name;
            startIndex += 4;
            var numArray = new int[num2];
            var table = new DataTable(tablename);
            for (int i = 0; i < num2; i++)
            {
                DataColumn column;
                int num4 = BitConverter.ToInt32(fileData, startIndex);
                numArray[i] = num4;
                string prefix = i.ToString(CultureInfo.InvariantCulture);
                switch (num4)
                {
                    case 1:
                        column = new DataColumn(prefix + "\n(Signed Byte)", typeof (sbyte))
                        {
                            DefaultValue = (sbyte) 0
                        };
                        break;

                    case 2:
                        column = new DataColumn(prefix + "\n(Byte)", typeof (byte))
                        {
                            DefaultValue = (byte) 0
                        };
                        break;

                    case 3:
                        column = new DataColumn(prefix + "\n(Int16)", typeof (short))
                        {
                            DefaultValue = (short) 0
                        };
                        break;

                    case 5:
                        column = new DataColumn(prefix + "\n(Int32)", typeof (int))
                        {
                            DefaultValue = 0
                        };
                        break;

                    case 6:
                        column = new DataColumn(prefix + "\n(UInt32)", typeof (uint))
                        {
                            DefaultValue = 0
                        };
                        break;

                    case 7:
                        column = new DataColumn(prefix + "\n(String)", typeof (string))
                        {
                            DefaultValue = ""
                        };
                        break;

                    case 8:
                        column = new DataColumn(prefix + "\n(Float)", typeof (float))
                        {
                            DefaultValue = 0f
                        };
                        break;

                    default:
                        column = new DataColumn(prefix + "\n(Unknown) " + num4.ToString(CultureInfo.InvariantCulture))
                        {
                            DefaultValue = 0
                        };
                        break;
                }
                table.Columns.Add(column);
                startIndex += 4;
            }

            int num5 = BitConverter.ToInt32(fileData, startIndex);
            startIndex += 4;
            for (int j = 0; (j < num5) && (startIndex < fileData.Length); j++)
            {
                DataRow row = table.NewRow();
                for (int k = 0; (k < num2) && (startIndex < fileData.Length); k++)
                {
                    int num8;
                    switch (numArray[k])
                    {
                        case 1:
                        {
                            row[k] = (fileData[startIndex] > 0x7f)
                                ? (fileData[startIndex] - 0x100)
                                : fileData[startIndex];
                            startIndex++;
                            continue;
                        }
                        case 2:
                        {
                            row[k] = fileData[startIndex];
                            startIndex++;
                            continue;
                        }
                        case 3:
                        {
                            row[k] = BitConverter.ToInt16(fileData, startIndex);
                            startIndex += 2;
                            continue;
                        }
                        case 5:
                        {
                            row[k] = BitConverter.ToInt32(fileData, startIndex);
                            startIndex += 4;
                            continue;
                        }
                        case 6:
                        {
                            row[k] = BitConverter.ToUInt32(fileData, startIndex);
                            startIndex += 4;
                            continue;
                        }
                        case 7:
                        {
                            num8 = BitConverter.ToInt32(fileData, startIndex);
                            startIndex += 4;
                            if (num8 > 0)
                            {
                                break;
                            }
                            continue;
                        }
                        case 8:
                        {
                            row[k] = BitConverter.ToSingle(fileData, startIndex);
                            startIndex += 4;
                            continue;
                        }
                        default:
                            goto Label_03F5;
                    }
                    var chArray = new char[num8];
                    for (int m = 0; m < num8; m++)
                    {
                        chArray[m] = (char) fileData[startIndex];
                        startIndex++;
                    }
                    row[k] = new string(chArray);
                    continue;
                    Label_03F5:
                    row[k] = BitConverter.ToInt32(fileData, startIndex);
                    startIndex += 4;
                }
                table.Rows.Add(row);
            }

            _tblSet.Tables.Add(table);
        }


     
        public static DataRow[] GetExtRow(byte index, int baseitem)
        {
            List<DataRow> drowlist = (from DataRow r in _tblSet.Tables[string.Format("item_ext_{0}_us.tbl", index)].Rows
                where Convert.ToInt32(r[2]) == baseitem || Convert.ToInt32(r[2]) == 0
                select r).ToList();
            return drowlist.ToArray();
        }

        public static readonly List<Item> MergedTable = new List<Item>();
    }
}
