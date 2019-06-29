﻿using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1300_0x1301_Formatter : IJT809MessagePackFormatter<JT809_0x1300_0x1301>
    {
        public readonly static JT809_0x1300_0x1301_Formatter Instance = new JT809_0x1300_0x1301_Formatter();

        public JT809_0x1300_0x1301 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1300_0x1301 jT809_0X1200_0X1301 = new JT809_0x1300_0x1301();
            jT809_0X1200_0X1301.ObjectType = (JT809_0x1301_ObjectType)reader.ReadByte();
            jT809_0X1200_0X1301.ObjectID = reader.ReadString(12);
            jT809_0X1200_0X1301.InfoID = reader.ReadUInt32();
            jT809_0X1200_0X1301.InfoLength = reader.ReadUInt32();
            jT809_0X1200_0X1301.InfoContent = reader.ReadString((int)jT809_0X1200_0X1301.InfoLength);
            return jT809_0X1200_0X1301;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1301 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ObjectType);
            writer.WriteStringPadRight(value.ObjectID, 12);
            writer.WriteUInt32(value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
