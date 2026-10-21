# unity-socket-echo

最原始的一步：**不借助任何网络框架，用 C# `Socket` 手写连接、收发包、定时器**。是 [unity-tcp-brawl](https://github.com/qianxue-snow/unity-tcp-brawl) 里那台 `EchoServer` 的最小客户端。

```
Assets/Script/Clock.cs      定时器回调练习（BeginInvoke 风格）
Assets/Script/Echo.cs       异步版：BeginConnect / BeginSend / BeginReceive + 回调缓存数组
Assets/Script/PollEcho.cs   轮询版：Socket.Poll(0, SelectMode.SelectRead)
Assets/Scenes/SampleScene   两个按钮：连接 / 发送
```

连的是 `127.0.0.1:8888`（`Echo.cs:27`、`PollEcho.cs:25`），所以本地要先起服务端：

```
cd ../unity-tcp-brawl 的 server 目录 && dotnet run --project EchoServer
```

## 说明

- Unity **2022.3.48f1c1**，2D 模板，无第三方包
- 只有 3 个脚本、0.2MB，是练手性质的小 demo，不含游戏内容
- `.gitignore` 排除了 `Library/`、`Temp/`、`Logs/`、`UserSettings/` 与 Unity 自动生成的 `.csproj/.sln`

## 状态

学习存档，最后一次改动 2026-04-02。
