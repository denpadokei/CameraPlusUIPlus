# CameraPlusUIPlus


CameraPlus のカメラプレビューに、カメラへ追従するフローティングメニューを追加する MOD です。CameraPlus のカメラ初期化を Harmony でフックして、BSML で作った画面をカメラの子オブジェクトとして配置します。

## 機能

- CameraPlus の `CameraPreviewQuad.Init` を Harmony の postfix でフックし、カメラ生成を検知する
- カメラ位置の右 0.9m に 80x100 サイズのフローティングスクリーンを生成する
- 生成したスクリーンをカメラの子オブジェクトにして、カメラの移動・回転に追従させる
- BSML で定義したメニュー (チェックボックスとプロファイル操作ボタン) をスクリーンに表示する
- CameraPlus の `CameraConfig.Load` / `CameraConfig.Save` にも postfix パッチを当て、読み込み・保存をイベントとして公開する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.17.0 |
| 依存 MOD | BSIPA ^4.1.3 / BeatSaberMarkupLanguage ^1.4.1 / CameraPlus ^6.0.0 / SiraUtil ^2.5.0 |

## インストール

1. Beat Saber を 1.17.0 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/CameraPlusUIPlus/releases) から `CameraPlusUIPlus-0.0.1-bs1.17.0.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

CameraPlus のカメラプレビューが初期化されると、カメラの横にフローティングメニューが表示されます。メニューはカメラに追従するため、カメラを動かしても同じ位置関係を保ちます。CameraPlus 側のカメラ設定は従来どおり CameraPlus の設定から変更してください。

## ビルド

```powershell
git clone https://github.com/denpadokei/CameraPlusUIPlus.git
cd CameraPlusUIPlus
dotnet build .\CameraPlusUIPlus\CameraPlusUIPlus.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。


> GitHub Actions によるビルドは未設定です。依存する CameraPlus 6.0 が BeatMods で配布されておらず、CI で参照アセンブリを解決できないため。

## ライセンス

MIT
