﻿using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessageBody;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9001_Formatter : IJT809MessagePackFormatter<JT809_0x9001>
    {
        public readonly static JT809_0x9001_Formatter Instance = new JT809_0x9001_Formatter();

        public JT809_0x9001 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9001 jT809_0X9001 = new JT809_0x9001();
            jT809_0X9001.VerifyCode = reader.ReadUInt32();
            return jT809_0X9001;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9001 value, IJT809Config config)
        {
            writer.WriteUInt32(value.VerifyCode);
        }
    }
}
