# Ofd2Pdf

Convert OFD files to PDF files (GUI + CLI) and support PDF to OFD conversion by CLI.

![Ofd2Pdf GUI](screenshot.png)

你可以单击打开 GUI，选择文件或者拖拽文件到列表，亦或者简单将文件拖拽到可执行文件上，它将自动完成转换过程。

## 主要功能

- OFD -> PDF（GUI + CLI）
- PDF -> OFD（CLI 扩展）

## 1. GitHub Actions 构建（推荐）

已经在 `.github/workflows/build-exe.yml` 配置了自动构建流程：

- Windows runner
- `NuGet/setup-nuget@v2`
- `msbuild` via `vswhere`
- 上传 artifact `Ofd2Pdf-Release`

使用方式

1. Push 代码到 `main`/`master`
2. 在 Actions 中查看构建执行结果
3. 下载 `Artifacts -> Ofd2Pdf-Release`，获得 `Ofd2Pdf.exe` 及依赖

## 2. CLI 使用指令

### 2.1 OFD -> PDF

```powershell
Ofd2Pdf.exe ofd2pdf input.ofd
Ofd2Pdf.exe ofd2pdf input1.ofd input2.ofd
```

输出文件：`input.pdf` / `input1.pdf` / `input2.pdf`。

### 2.2 PDF -> OFD

```powershell
Ofd2Pdf.exe pdf2ofd input.pdf
Ofd2Pdf.exe pdf2ofd input1.pdf input2.pdf
```

输出文件：`input.ofd` / `input1.ofd` / `input2.ofd`。

### 2.3 兼容旧用法（默认 OFD->PDF）

```powershell
Ofd2Pdf.exe input.ofd input2.ofd
```

没有明确命令时，默认执行 `ofd2pdf`。

## 3. GUI 模式

```powershell
Ofd2Pdf.exe
```

启动 WinForms 图形界面。

## 4. 退出码

- `0`: 全部文件转换成功
- `1`: 存在转换失败

## 5. 额外发布建议

- 生成 ZIP：`Ofd2Pdf/bin/Release/*.exe`/`.dll`
- 可进一步加 GitHub Release 自动发布：`actions/create-release` + `upload-release-asset`

## 6. 编译（开发）

如果在本地调试：

```powershell
nuget restore Ofd2Pdf.sln
msbuild Ofd2Pdf.sln /p:Configuration=Release /p:Platform="Any CPU" /m
```

（正式发布优先走 CI，不建议在主要环境中本地构建）

