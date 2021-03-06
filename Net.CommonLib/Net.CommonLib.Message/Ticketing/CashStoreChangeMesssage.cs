﻿/*******************************************************************
 * * 文件名：
 * * 文件作用：
 * *-------------------------------------------------------------------
 * * 修改历史记录：
 * * 修改时间      修改人    修改内容概要
 * * 2013-02-23    xwj       新增
 * *******************************************************************/

namespace Net.CommonLib.Message.Ticketing
{
    public class CashStoreChangeMesssage : BaseMessage
    {
        /// <summary>
        /// 线路 CHAR（2）
        /// </summary>
        public string LineId { get; set; }

        /// <summary>
        /// 车站(4)
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// 操作员ID char(6)
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作员2ID char(6)
        /// </summary>
        public string DoublePrivilegeId { get; set; }

        /// <summary>
        /// 创建时间 CHAR(14)
        /// </summary>
        public string OperateTime { get; set; }

        /// <summary>
        /// 操作类型 CHAR(2)
        /// </summary>
        public string OperateType { get; set; }

        /// <summary>
        /// 库存管理类型 CHAR(4)
        /// </summary>
        public string CashKind { get; set; }

        /// <summary>
        /// 操作数量 CHAR(8)
        /// </summary>
        public string ChangeAmt { get; set; }

        /// <summary>
        /// 结余数量 CHAR(8)
        /// </summary>
        public string RemainAmt { get; set; }

        /// <summary>
        /// 班次10
        /// </summary>
        public string ShiftId { get; set; }

        /// <summary>
        /// 设备编号8
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 班次标志2
        /// </summary>
        public string ShiftFlag { get; set; }

        public CashStoreChangeMesssage()
        {
            msgType = MsgType.TicketingCashStoreChange;
        }

        public CashStoreChangeMesssage(byte[] bytes)
            : base(bytes)
        {
            msgType = MsgType.TicketingCashStoreChange;
        }

        public override void Decode()
        {
            base.Decode();
            LineId = GetNextString(2);
            StationId = GetNextString(4);
            OperatorId = GetNextString(6);
            DoublePrivilegeId = GetNextString(6);
            OperateTime = GetNextString(14);

            OperateType = GetNextString(2);
            CashKind = GetNextString(2);

            ChangeAmt = GetNextString(8);
            RemainAmt = GetNextString(8);

            ShiftId = GetNextString(10);
            DeviceId = GetNextString(8);
            ShiftFlag = GetNextString(2);
        }

        public override void Encode()
        {
            encodeBuf.Clear();

            encodeBuf.AddRange(AddString(LineId, 2));
            encodeBuf.AddRange(AddString(StationId, 4));
            encodeBuf.AddRange(AddString(OperatorId, 6));
            encodeBuf.AddRange(AddString(DoublePrivilegeId, 6));
            encodeBuf.AddRange(AddString(OperateTime, 14));
            encodeBuf.AddRange(AddString(OperateType, 2));
            encodeBuf.AddRange(AddString(CashKind, 2));

            encodeBuf.AddRange(AddString(ChangeAmt.PadLeft(8, '0'), 8));
            encodeBuf.AddRange(AddString(RemainAmt.PadLeft(8, '0'), 8));

            encodeBuf.AddRange(AddString(ShiftId.PadLeft(10, ' '), 10));
            encodeBuf.AddRange(AddString(DeviceId.PadLeft(8, ' '), 8));
            encodeBuf.AddRange(AddString(ShiftFlag.PadLeft(2, ' '), 2));
        }
    }
}