﻿/*******************************************************************
 * * 文件名：
 * * 文件作用：
 * *-------------------------------------------------------------------
 * * 修改历史记录：
 * * 修改时间      修改人    修改内容概要
 * * 2013-02-23    xwj       新增
 * *******************************************************************/

namespace Net.CommonLib.Message.Transaction
{
    /// <summary>
    /// TVM发售单程票(现金)
    /// </summary>
    public class TXTVMSjtSale : BaseMessage
    {
        /// <summary>
        /// 发生交易设备代码
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 交易序列组号(2)
        /// </summary>
        public string TxnGroupNumber { get; set; }

        /// <summary>
        /// 交易序列号（8）
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 车站编号
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// 交易类型)
        /// </summary>
        public string TxnType { get; set; }

        /// <summary>
        /// 票卡主类型
        /// </summary>

        public string TicketMainType { get; set; }

        // <summary>
        /// 票卡子类型
        /// </summary>
        public string TicketSubType { get; set; }

        /// <summary>
        /// 票价区域代码
        /// </summary>
        public string TicketPriceCode { get; set; }

        /// <summary>
        /// sam卡卡号
        /// </summary>
        public string SamCardNumber { get; set; }

        /// <summary>
        /// 票卡逻辑卡号
        /// </summary>
        public string TicketLogicalId { get; set; }

        /// <summary>
        /// 票卡写操作计数
        /// </summary>
        public string TicketWriteCouter { get; set; }

        /// <summary>
        /// 本次票卡操作金额
        /// </summary>
        public string ThisTicketOperateAmt { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public string TicketRemainAmt { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public string TxnTime { get; set; }

        /// <summary>
        /// 上次交易设备编号
        /// </summary>
        public string LastTxnDeviceId { get; set; }

        /// <summary>
        /// 上次交易序列号
        /// </summary>
        public string LastTxnSerialNumber { get; set; }

        /// <summary>
        /// 上次交易金额
        /// </summary>
        public string LastTxnAmt { get; set; }

        /// <summary>
        /// 上次交易时间
        /// </summary>
        public string LastTxnTime { get; set; }

        /// <summary>
        /// 交易验证码
        /// </summary>
        public string TACCode { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 支付卡类型
        /// </summary>
        public string PaymentCardId { get; set; }

        /// <summary>
        /// 目的车站
        /// </summary>
        public string DestinationStationId { get; set; }

        /// <summary>
        /// 预留
        /// </summary>
        public string Spare { get; set; }

        public TXTVMSjtSale()
        {
            msgType = MsgType.TxnTvmSjtSale;
        }

        public TXTVMSjtSale(byte[] bytes)
            : base(bytes)
        {
            msgType = MsgType.TxnTvmSjtSale;
        }

        public override void Decode()
        {
            base.Decode();

            DeviceId = GetNextString(8);
            TxnGroupNumber = GetNextString(2);
            SerialNumber = GetNextString(8);
            StationId = GetNextString(4);
            TxnType = GetNextString(2);
            TicketMainType = GetNextString(2);
            TicketSubType = GetNextString(2);
            TicketPriceCode = GetNextString(2);
            SamCardNumber = GetNextString(8);
            TicketLogicalId = GetNextString(16);
            TicketWriteCouter = GetNextString(6);
            ThisTicketOperateAmt = GetNextString(8);
            TicketRemainAmt = GetNextString(8);
            TxnTime = GetNextString(14);
            LastTxnDeviceId = GetNextString(8);
            LastTxnSerialNumber = GetNextString(8);
            LastTxnAmt = GetNextString(8);
            LastTxnTime = GetNextString(14);
            TACCode = GetNextString(8);
            PaymentType = GetNextString(1);
            PaymentCardId = GetNextString(16);
            DestinationStationId = GetNextString(4);
            Spare = GetNextString(23);
        }

        public override void Encode()
        {
            encodeBuf.Clear();
            encodeBuf.AddRange(AddString(DeviceId, 8));
            encodeBuf.AddRange(AddString(TxnGroupNumber.PadLeft(2, '0'), 2));
            encodeBuf.AddRange(AddString(SerialNumber.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(StationId, 4));
            encodeBuf.AddRange(AddString(TxnType, 2));
            encodeBuf.AddRange(AddString(TicketMainType, 2));
            encodeBuf.AddRange(AddString(TicketSubType, 2));
            encodeBuf.AddRange(AddString(TicketPriceCode, 2));
            encodeBuf.AddRange(AddString(SamCardNumber, 8));
            encodeBuf.AddRange(AddString(TicketLogicalId, 16));
            encodeBuf.AddRange(AddString(TicketWriteCouter.PadLeft(6, '0'), 6));
            encodeBuf.AddRange(AddString(ThisTicketOperateAmt.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(TicketRemainAmt.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(TxnTime, 14));
            encodeBuf.AddRange(AddString(LastTxnDeviceId, 8));
            encodeBuf.AddRange(AddString(LastTxnSerialNumber.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(LastTxnAmt.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(LastTxnTime, 14));
            encodeBuf.AddRange(AddString(TACCode, 8));
            encodeBuf.AddRange(AddString(PaymentType, 1));
            encodeBuf.AddRange(AddString(PaymentCardId, 16));
            encodeBuf.AddRange(AddString(DestinationStationId, 4));
            encodeBuf.AddRange(AddString(Spare.PadLeft(23, '0'), 23));
        }
    }
}