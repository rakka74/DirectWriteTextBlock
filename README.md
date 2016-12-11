# DirectWriteTextBlock

[WPFDXInterop](https://github.com/Microsoft/WPFDXInterop)を使ってDirectWriteで描画するWPFのTextBlockもどき。

ListViewでの使用で項目の数がかなり多い場合、仮装モードが有効で、
```
VirtualizingPanel.VirtualizationMode="Recycling"
```
の場合のみ正常に動作します。
