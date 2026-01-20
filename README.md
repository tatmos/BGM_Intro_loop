# BGM_Intro_loop

## 概要
Unity で「イントロ付きループ BGM」を簡単に再生するためのサンプルプロジェクトです。  
`BGMController.cs` を対象シーンに追加し、イントロ用クリップとループ用クリップを指定するだけで、イントロ再生後にシームレスなループへ移行します。

## 構成
| パス | 内容 |
| --- | --- |
| `intro_loop/Assets/intro_loop/BGMController.cs` | イントロ再生後にループ再生へ切り替える制御スクリプト |
| `intro_loop/Assets/intro_loop/skykid_intro.wav` | イントロ用のサンプル音源 |
| `intro_loop/Assets/intro_loop/skykid_loop.wav` | ループ用のサンプル音源 |
| `intro_loop/Assets/intro_loop/intro_loop_unity.unity` | 動作確認用のサンプルシーン |
| `intro_loop/Assets/timing/*` | タイミング確認用のシーン・サンプル素材 |

## 使い方
### 手順
1. Unity で本プロジェクトを開きます。
2. BGM を流したいシーンのカメラまたは空の GameObject に `BGMController.cs` を追加します。
3. インスペクターから `intro` にイントロ用 AudioClip、`loop` にループ用 AudioClip を設定します。
4. 必要に応じて `delay` を調整し、再生タイミングを微調整します（デフォルト 0.1 秒）。
5. 再生すると、イントロが流れた後に自動でループへ移行します。

### Inspector 設定の目安
- **intro**: イントロ用の AudioClip（例: `skykid_intro.wav`）
- **loop**: ループ用の AudioClip（例: `skykid_loop.wav`）
- **delay**: 再生タイミングの微調整（0.05〜0.2 秒程度で調整）

## 主な機能
- イントロ → ループの自動切り替え（`PlayScheduled` を使用）。
- 2 系統の AudioSource を使い、ループ開始タイミングを正確にスケジューリング。
- イントロ／ループ未設定時の分岐に対応し、必要最低限の設定で動作。

---

超シンプルにイントロ付きループを実現するスクリプトの例です。

必要なのは 
BGMController.cs
になります。

自分のプロジェクトの
BGMをつけたいシーンのカメラか空のGameObjectに
BGMController.csをAddCompornentで追加して
AuidoClipをintroとloopにセットするだけで、
イントロ付きループが再生できます。

カタログIPゲームジャム https://open.channel.or.jp/gamejam.php 
で使えるかと思います。

動画：　http://www.nicovideo.jp/watch/sm27490070
Qiita:　http://qiita.com/tatmos/items/d06ce8af00ad3a0d0ac1
