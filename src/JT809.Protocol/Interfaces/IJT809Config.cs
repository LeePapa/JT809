﻿using JT809.Protocol.Configs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809Config
    {
        string ConfigId { get; }
        /// <summary>
        /// 消息流水号
        /// </summary>
        IJT809MsgSNDistributed MsgSNDistributed { get; set; }
        /// <summary>
        /// 头部选项
        /// </summary>
        JT809HeaderOptions HeaderOptions { get; set; }
        /// <summary>
        /// 统一编码
        /// </summary>
        Encoding Encoding { get; set; }
        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        bool SkipCRCCode { get; set; }
        /// <summary>
        /// 加密接口
        /// </summary>
        IJT809Encrypt Encrypt { get; set; }
        /// <summary>
        /// 加密选项
        /// </summary>
        JT809EncryptOptions EncryptOptions { get; set; }
        /// <summary>
        /// 全局注册外部程序集
        /// </summary>
        /// <param name="externalAssemblies"></param>
        /// <returns></returns>
        IJT809Config Register(params Assembly[] externalAssemblies);
    }
}
