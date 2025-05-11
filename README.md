# 考勤数据处理系统（C# WinForms）

## 项目简介
本项目是一个基于 C# WinForms 的考勤数据处理工具，支持从 Excel 文件导入考勤数据，自动拆分、分类打卡时间，计算工作时长，并支持自定义设置、日志管理。适用于日常考勤统计、工时分析等场景。

## 主要功能
- 支持 Excel 文件（.xlsx）导入与导出
- 自动识别并分类打卡时间（早上上班、中午下班、下午上班、晚上下班）
- 自动计算每日工作时长，支持自定义工作时间规则
- 支持异常考勤检测（如缺卡、迟到、早退等）
- 设置界面支持自定义参数，实时生效
- 日志管理，异常信息自动保存
- 友好的 WinForms 图形界面，支持进度条、日志区、结果区等


## 使用方法

### 依赖环境
- Windows 10/11
- .NET 8.0 SDK 及以上
- Visual Studio 2022 或更高版本（推荐）

### 编译与运行
1. 克隆本仓库：
   ```bash
   git clone https://github.com/chenmo263/TimeProcessor.git
   cd 仓库目录
   ```
2. 用 Visual Studio 打开解决方案，或命令行编译：
   ```bash
   dotnet build -c Release
   dotnet run --project TimeProcessor/TimeProcessor/TimeProcessor.csproj
   ```
3. 运行后，按界面提示选择 Excel 文件，设置参数，点击处理即可。

### 设置说明
- 所有参数（如工作时间、有效打卡时间等）均可在"设置"界面修改，保存后立即生效。
- 设置数据保存在 `appsettings.json` 文件中。

### 日志与异常
- 日志信息会显示在主界面日志区，并自动保存到 `logs/日期.log` 文件。
- 支持一键清空日志。



## 贡献方式
1. Fork 本仓库，创建新分支进行开发。
2. 提交 Pull Request，描述你的修改内容。
3. 欢迎提交 issue 反馈 bug 或建议。

## 联系方式
- 作者：陈默263（Chen Mo 263）
- 邮箱：chenmo263@chenmo2.site
- 项目主页：https://github.com/chenmo263/TimeProcessor

---
如有问题或建议，欢迎随时联系或提交 issue！ 