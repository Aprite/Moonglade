param(
    [string]$zipFileName=$(throw "请指定要部署的文件 -zipFileName 要部署的zip文件的名称")
)

$txServer="ctyun.aprite.cn"

Write-Host "------ 开始发布站点：$($txServer) ------"

scp .\publish\$zipFileName root@$($txServer):/aprite/apps/aprite_cn/
ssh root@$($txServer) "cd /aprite/apps/aprite_cn/; ./deployprod.sh $zipFileName"

Write-Host "------ 结束发布站点：$($txServer) ------"
