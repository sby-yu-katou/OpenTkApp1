using System.Windows;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Linq;
using System;
using OpenTkApp1.Views.Items;

namespace OpenTkApp1.Views;

/// <summary>
/// 折れ線グラフを描画する機能を提供します。
/// </summary>
public class TkLineGraphItem : FrameworkElement, ITkGraphicsItem
{
    #region XData

    /// <summary>
    /// XData 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty XDataProperty = DependencyProperty.Register("XData", typeof(double[]), typeof(TkLineGraphItem), new PropertyMetadata(null, OnXDataPropertyChanged));

    /// <summary>
    /// 横軸データを取得または設定します。
    /// </summary>
    public double[]? XData
    {
        get => (double[]?)GetValue(XDataProperty);
        set => SetValue(XDataProperty, value);
    }

    /// <summary>
    /// XData プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnXDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion XData

    #region YData

    /// <summary>
    /// YData 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty YDataProperty = DependencyProperty.Register("YData", typeof(double[]), typeof(TkLineGraphItem), new PropertyMetadata(null, OnYDataPropertyChanged));

    /// <summary>
    /// 縦軸データを取得または設定します。
    /// </summary>
    public double[]? YData
    {
        get => (double[]?)GetValue(YDataProperty);
        set => SetValue(YDataProperty, value);
    }

    /// <summary>
    /// YData プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnYDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion YData

    #region XMax
    /// <summary>
    /// XMax 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty XMaxProperty = DependencyProperty.Register("XMax", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnXMaxPropertyChanged));

    public double XMax
    {
        get => (double)GetValue(XMaxProperty);
        set => SetValue(XMaxProperty, value);
    }

    /// <summary>
    /// XMax プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnXMaxPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion XMax

    #region XMin
    /// <summary>
    /// XMin 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty XMinProperty = DependencyProperty.Register("XMin", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnXMinPropertyChanged));

    public double XMin
    {
        get => (double)GetValue(XMinProperty);
        set => SetValue(XMinProperty, value);
    }
    /// <summary>
    /// XMin プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnXMinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion XMin

    #region YMax
    /// <summary>
    /// YMax 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty YMaxProperty = DependencyProperty.Register("YMax", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnYMaxPropertyChanged));

    public double YMax
    {
        get => (double)GetValue(YMaxProperty);
        set => SetValue(YMaxProperty, value);
    }

    /// <summary>
    /// YMax プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnYMaxPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion YMax

    #region YMin
    /// <summary>
    /// YMin 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty YMinProperty = DependencyProperty.Register("YMin", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnYMinPropertyChanged));

    public double YMin
    {
        get => (double)GetValue(YMinProperty);
        set => SetValue(YMinProperty, value);
    }

    /// <summary>
    /// YMin プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnYMinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion YMin

    #region YCenter
    /// <summary>
    /// YCenter 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty YCenterProperty = DependencyProperty.Register("YCenter", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnYCenterPropertyChanged));

    public double YCenter
    {
        get => (double)GetValue(YCenterProperty);
        set => SetValue(YCenterProperty, value);
    }

    /// <summary>
    /// YCenter プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnYCenterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion YCenter

    #region PlotSize
    /// <summary>
    /// PlotSize 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty PlotSizeProperty = DependencyProperty.Register("PlotSize", typeof(double), typeof(TkLineGraphItem), new PropertyMetadata(0.0, OnPlotSizePropertyChanged));

    public double PlotSize
    {
        get => (double)GetValue(PlotSizeProperty);
        set => SetValue(PlotSizeProperty, value);
    }

    /// <summary>
    /// PlotSize プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnPlotSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion PlotSize

    #region PlotType
    /// <summary>
    /// PlotType 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty PlotTypeProperty = DependencyProperty.Register("PlotType", typeof(MarkerTypes), typeof(TkLineGraphItem), new PropertyMetadata(MarkerTypes.Ellipse, OnPlotTypePropertyChanged));

    public MarkerTypes PlotType
    {
        get => (MarkerTypes)GetValue(PlotTypeProperty);
        set => SetValue(PlotTypeProperty, value);
    }

    /// <summary>
    /// PlotType プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param
    private static void OnPlotTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion PlotType

    #region PlotColor
    /// <summary>
    /// PlotColor 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty PlotColorProperty = DependencyProperty.Register("PlotColor", typeof(Color4), typeof(TkLineGraphItem), new PropertyMetadata(Color4.White, OnPlotColorPropertyChanged));

    public Color4 PlotColor
    {
        get => (Color4)GetValue(PlotColorProperty);
        set => SetValue(PlotColorProperty, value);
    }

    /// <summary>
    /// PlotColor プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param
    private static void OnPlotColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion PlotColor

    #region ISPlot
    /// <summary>
    /// IsPlot 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty IsPlotProperty = DependencyProperty.Register("IsPlot", typeof(bool), typeof(TkLineGraphItem), new PropertyMetadata(false, OnIsPlotPropertyChanged));

    public bool IsPlot
    {
        get => (bool)GetValue(IsPlotProperty);
        set => SetValue(IsPlotProperty, value);
    }

    /// <summary>
    /// IsPlot プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnIsPlotPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion IsPlot

    #region IsGraphCursor
    /// <summary>
    /// IsPlot 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty IsGraphCursorProperty = DependencyProperty.Register("IsGraphCursor", typeof(bool), typeof(TkLineGraphItem), new PropertyMetadata(false, OnIsGraphCursorPropertyChanged));

    public bool IsGraphCursor
    {
        get => (bool)GetValue(IsGraphCursorProperty);
        set => SetValue(IsGraphCursorProperty, value);
    }

    /// <summary>
    /// IsPlot プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnIsGraphCursorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion IsGraphCursor

    #region GraphCursorColor
    /// <summary>
    /// LineColor 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty GraphCursorColorProperty = DependencyProperty.Register("GraphCursorColor", typeof(Color4), typeof(TkLineGraphItem), new PropertyMetadata(Color4.White, OnGraphCursorColorPropertyChanged));

    public Color4 GraphCursorColor
    {
        get => (Color4)GetValue(GraphCursorColorProperty);
        set => SetValue(GraphCursorColorProperty, value);
    }

    /// <summary>
    /// LineColor プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnGraphCursorColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion GraphCursorColor

    #region LineColor
    /// <summary>
    /// LineColor 依存関係プロパティの定義を表します。
    /// </summary>
    public static readonly DependencyProperty LineColorProperty = DependencyProperty.Register("LineColor", typeof(Color4), typeof(TkLineGraphItem), new PropertyMetadata(Color4.White, OnLineColorPropertyChanged));

    public Color4 LineColor
    {
        get => (Color4)GetValue(LineColorProperty);
        set => SetValue(LineColorProperty, value);
    }

    /// <summary>
    /// LineColor プロパティ変更イベントハンドラ
    /// </summary>
    /// <param name="d">イベント発行元</param>
    /// <param name="e">イベント引数</param>
    private static void OnLineColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }

    #endregion LineColor

    #region Legend
    public static readonly DependencyProperty LegndProperty = DependencyProperty.Register("Legend", typeof(string), typeof(TkLineGraphItem), new PropertyMetadata(null, OnLegendPropertyChanged));

    public string Legend
    {
        get => (string)GetValue(LegndProperty);
        set => SetValue(LegndProperty, value);
    }

    private static void OnLegendPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TKLineGraph)?.Render();
    }
    #endregion Legend
}