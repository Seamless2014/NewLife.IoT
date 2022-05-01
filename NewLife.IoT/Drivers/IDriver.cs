﻿using NewLife.IoT.ThingModels;
using NewLife.Log;

namespace NewLife.IoT.Drivers;

/// <summary>协议驱动接口</summary>
public interface IDriver
{
    #region 参数
    /// <summary>
    /// 创建驱动参数对象，可序列化成Xml/Json作为该协议的参数模板
    /// </summary>
    /// <returns></returns>
    IDriverParameter CreateParameter();
    #endregion

    #region 核心方法
    /// <summary>
    /// 打开设备驱动，传入参数。一个物理设备可能有多个逻辑设备共用，需要以节点来区分
    /// </summary>
    /// <param name="device">逻辑设备</param>
    /// <param name="parameters">参数</param>
    /// <returns>节点对象，可存储站号等信息，仅驱动自己识别</returns>
    INode Open(IDevice device, IDictionary<String, Object> parameters);

    /// <summary>
    /// 关闭设备驱动
    /// </summary>
    /// <param name="node"></param>
    void Close(INode node);

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="node">节点对象，可存储站号等信息，仅驱动自己识别</param>
    /// <param name="points">点位集合</param>
    /// <returns></returns>
    IDictionary<String, Object> Read(INode node, IPoint[] points);

    /// <summary>
    /// 写入数据
    /// </summary>
    /// <param name="node">节点对象，可存储站号等信息，仅驱动自己识别</param>
    /// <param name="point">点位</param>
    /// <param name="value">数值</param>
    Object Write(INode node, IPoint point, Object value);

    /// <summary>
    /// 控制设备，特殊功能使用
    /// </summary>
    /// <param name="node">节点对象，可存储站号等信息，仅驱动自己识别</param>
    /// <param name="parameters">参数</param>
    void Control(INode node, IDictionary<String, Object> parameters);
    #endregion

    #region 日志
    /// <summary>日志</summary>
    ILog Log { get; set; }

    /// <summary>性能追踪器</summary>
    ITracer Tracer { get; set; }
    #endregion
}

/// <summary>扩展</summary>
public static class DriverExtensions
{
    ///// <summary>写日志</summary>
    ///// <param name="driver"></param>
    ///// <param name="format"></param>
    ///// <param name="args"></param>
    //public static void WriteLog(this IDriver driver, String format, params Object[] args) => driver.Log?.Info(format, args);

    ///// <summary>
    ///// 打开设备驱动
    ///// </summary>
    ///// <param name="driver"></param>
    ///// <param name="device"></param>
    ///// <param name="parameter"></param>
    ///// <returns></returns>
    //public static INode Open(this IDriver driver, IDevice device, IDriverParameter parameter)
    //{
    //    var ps = parameter?.Serialize();
    //    var node = driver.Open(device, ps);

    //    if (node.Driver == null) node.Driver = driver;
    //    if (node.Device == null) node.Device = device;
    //    if (node.Parameter == node) node.Parameter = parameter;

    //    return node;
    //}
}