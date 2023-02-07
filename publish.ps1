$publishBasePath="./publish"

#
# 发布前清空发布目录
#
if (Test-Path -Path "$($publishBasePath)/dist") {
    Remove-Item -Recurse "$($publishBasePath)/dist"
}

#
# 发布
#
$HttpApiProject="./src/Moonglade.Web/Moonglade.Web.csproj"
dotnet restore --force --runtime linux-x64 --force-evaluate $HttpApiProject
& dotnet build --no-incremental --no-restore --runtime linux-x64 --self-contained --configuration Release $HttpApiProject
& dotnet publish --no-build --force --nologo --runtime linux-x64 --self-contained --configuration Release --output "$($publishBasePath)/dist" $HttpApiProject

#
# 创建 zip 压缩包
#
$zipFileName="aprite-cn-$(Get-Date -Format 'yyyy_MM_dd__HH_mm_ss_fff').zip"
Compress-Archive -Path "$($publishBasePath)/dist" -DestinationPath "$($publishBasePath)/$($zipFileName)"
Write-Host "压缩文件名称: $($zipFileName)"
