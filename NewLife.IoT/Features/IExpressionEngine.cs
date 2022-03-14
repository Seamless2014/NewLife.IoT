﻿namespace NewLife.IoT.Features;

/// <summary>
/// 表达式引擎接口。用于动态解析执行表达式字符串
/// </summary>
public interface IExpressionEngine
{
    /// <summary>
    /// 最后更新时间。用于判断是否需要重新解析表达式
    /// </summary>
    DateTime UpdateTime { get; set; }

    /// <summary>
    /// 解析表达式
    /// </summary>
    /// <param name="expression">表达式字符串</param>
    /// <param name="parameters">参数名称与类型</param>
    /// <returns></returns>
    Object Parse(String expression, IDictionary<String, Type> parameters);

    /// <summary>
    /// 解析表达式
    /// </summary>
    /// <param name="expression">表达式字符串</param>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <returns></returns>
    public virtual Object Parse(String expression, String name, Type type) => Parse(expression, new Dictionary<String, Type> { { name, type } });

    /// <summary>
    /// 执行表达式
    /// </summary>
    /// <param name="arguments">参数名称与数值</param>
    /// <returns></returns>
    Object Invoke(IDictionary<String, Object> arguments);

    /// <summary>
    /// 执行表达式
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="value">参数数值</param>
    /// <returns></returns>
    public virtual Object Invoke(String name, Object value) => Invoke(new Dictionary<String, Object> { { name, value } });
}