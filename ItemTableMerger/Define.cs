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

namespace ItemTableMerger
{
    /// <summary>
    /// Data holder for an item.
    /// </summary>
    [Serializable]
    public struct Item
    {
        public int Num;
        public string strName;//
        public string strExtName;//
        public string strDesc;//
        public string strExtDesc;//
        public int Extension;
        public int isUnique;
        public byte Kind;//
        public byte Slot;//
        public byte Race;//
        public byte Class;//
        public short Damage;//
        public short Delay;//
        public short Range;//
        public short Weight;//
        public short Duration;//
        public long BuyPrice;
        public long SellPrice;
        public short Ac;//
        public byte Countable;
        public int Effect1;//
        public int Effect2;//
        public short ReqLevel;//
        public byte ReqLevelMax;
        public short ReqRank;//
        public short ReqTitle;//
        public short ReqStr;//
        public short ReqSta;//
        public short ReqDex;//
        public short ReqIntel;//
        public short ReqCha;//
        public byte SellingGroup;//
        public byte ItemType;//
        public short Hitrate;//
        public short EvasionRate;//
        public short DaggerAc;//
        public short SwordAc;//
        public short MaceAc;//
        public short AxeAc;//
        public short SpearAc;//
        public short BowAc;//
        public byte FireDamage;//
        public byte IceDamage;//
        public byte LightningDamage;//
        public byte PoisonDamage;//
        public byte HPDrain;//
        public byte MPDamage;//
        public byte MPDrain;//
        public byte MirrorDamage;
        public byte Droprate;
        public short StrB;//
        public short StaB;//
        public short DexB;//
        public short IntelB;//
        public short ChaB;//
        public short MaxHpB;//
        public short MaxMpB;//
        public short FireR;//
        public short ColdR;//
        public short LightningR;//
        public short MagicR;//
        public short PoisonR;//
        public short CurseR;//
        public int IconID;//
        public byte ItemGrade;

        bool isCountable
        {
            get { return Countable == 1; }
        }


    }
}
