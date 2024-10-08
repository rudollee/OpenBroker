﻿using System.Collections.Generic;

namespace LsOpenApi.Models;
/// <summary>
/// 뉴스본문(t3102)
/// </summary>
internal class t3102 : LsResponseCore
{
	public t3102InBlock InBlock { get; set; } = new();
	public t3102OutBlock[] t3102OutBlock { get; set; } = Array.Empty<t3102OutBlock>();
	public IEnumerable<t3102OutBlock1> t3102OutBlock1 { get; set; } = Enumerable.Empty<t3102OutBlock1>();
	public t3102OutBlock2 t3102OutBlock2 { get; set; } = new();
}

/// <summary>
/// 뉴스본문(t3102) - InBlock
/// </summary>
internal class t3102InBlock
{
	/// <summary>뉴스번호</summary>
	public string sNewsno { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock
/// </summary>
internal class t3102OutBlock
{
	/// <summary>뉴스종목</summary>
	public string sJongcode { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock1
/// </summary>
internal class t3102OutBlock1
{
	/// <summary>뉴스본문</summary>
	public string sBody { get; set; } = string.Empty;
}

/// <summary>
/// 뉴스본문(t3102) - OutBlock2
/// </summary>
internal class t3102OutBlock2
{
	/// <summary>뉴스타이틀</summary>
	public string sTitle { get; set; } = string.Empty;
}

