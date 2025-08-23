namespace LsOpenApi.Models;
/// <summary>
/// 주식선물호가조회(API용)(t8403)
/// </summary>
internal class t8403 : LsResponseCore
{
	public t2105InBlock t8403InBlock { get; set; } = new();
	public t8403OutBlock t8403OutBlock { get; set; } = new();
}

/// <summary>
/// 주식선물호가조회(API용)(t8403) - OutBlock
/// </summary>
internal class t8403OutBlock : t2105OutBlock
{
	/// <summary>매도호가6</summary>
	public long offerho6 { get; set; }

	/// <summary>매수호가6</summary>
	public long bidho6 { get; set; }

	/// <summary>매도호가수량6</summary>
	public long offerrem6 { get; set; }

	/// <summary>매수호가수량6</summary>
	public long bidrem6 { get; set; }

	/// <summary>매도호가건수6</summary>
	public long dcnt6 { get; set; }

	/// <summary>매수호가건수6</summary>
	public long scnt6 { get; set; }

	/// <summary>매도호가7</summary>
	public long offerho7 { get; set; }

	/// <summary>매수호가7</summary>
	public long bidho7 { get; set; }

	/// <summary>매도호가수량7</summary>
	public long offerrem7 { get; set; }

	/// <summary>매수호가수량7</summary>
	public long bidrem7 { get; set; }

	/// <summary>매도호가건수7</summary>
	public long dcnt7 { get; set; }

	/// <summary>매수호가건수7</summary>
	public long scnt7 { get; set; }

	/// <summary>매도호가8</summary>
	public long offerho8 { get; set; }

	/// <summary>매수호가8</summary>
	public long bidho8 { get; set; }

	/// <summary>매도호가수량8</summary>
	public long offerrem8 { get; set; }

	/// <summary>매수호가수량8</summary>
	public long bidrem8 { get; set; }

	/// <summary>매도호가건수8</summary>
	public long dcnt8 { get; set; }

	/// <summary>매수호가건수8</summary>
	public long scnt8 { get; set; }

	/// <summary>매도호가9</summary>
	public long offerho9 { get; set; }

	/// <summary>매수호가9</summary>
	public long bidho9 { get; set; }

	/// <summary>매도호가수량9</summary>
	public long offerrem9 { get; set; }

	/// <summary>매수호가수량9</summary>
	public long bidrem9 { get; set; }

	/// <summary>매도호가건수9</summary>
	public long dcnt9 { get; set; }

	/// <summary>매수호가건수9</summary>
	public long scnt9 { get; set; }

	/// <summary>매도호가10</summary>
	public long offerho10 { get; set; }

	/// <summary>매수호가10</summary>
	public long bidho10 { get; set; }

	/// <summary>매도호가수량10</summary>
	public long offerrem10 { get; set; }

	/// <summary>매수호가수량10</summary>
	public long bidrem10 { get; set; }

	/// <summary>매도호가건수10</summary>
	public long dcnt10 { get; set; }

	/// <summary>매수호가건수10</summary>
	public long scnt10 { get; set; }
}