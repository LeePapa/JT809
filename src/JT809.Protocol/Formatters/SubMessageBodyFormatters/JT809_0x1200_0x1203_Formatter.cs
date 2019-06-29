﻿using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1200_0x1203_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x1203>
    {
        public readonly static JT809_0x1200_0x1203_Formatter Instance = new JT809_0x1200_0x1203_Formatter();

        public JT809_0x1200_0x1203 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = new JT809_0x1200_0x1203();
            jT809_0X1200_0X1203.GNSSCount = reader.ReadByte();
            jT809_0X1200_0X1203.GNSS = new List<JT809_0x1200_0x1202>();
            if (jT809_0X1200_0X1203.GNSSCount > 0)
            {
                for (int i = 0; i < jT809_0X1200_0X1203.GNSSCount; i++)
                {
                    try
                    {
                        JT809MessagePackReader jT809_0x1200_0x1202Reader = new JT809MessagePackReader(reader.ReadArray(36));
                        var jT809_0x1200_0x1202= JT809_0x1200_0x1202_Formatter.Instance.Deserialize(ref jT809_0x1200_0x1202Reader, config);
                        jT809_0X1200_0X1203.GNSS.Add(jT809_0x1200_0x1202);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return jT809_0X1200_0X1203;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1203 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.GNSS.Count);
            foreach (var item in value.GNSS)
            {
                try
                {
                    JT809_0x1200_0x1202_Formatter.Instance.Serialize(ref writer, item, config);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
