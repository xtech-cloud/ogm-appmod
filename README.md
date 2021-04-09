# 使用方法

1. 创建模块文件夹
2. 编写generator.yml文件，例如
```yaml
#组织名
org: ogm
#模块名
mod: startkit
#布局
layouts:
-
  #方法
  method: Healthy.Echo
  #页面
  page: PostForm
```
3. 在文件夹中运行 `python ../generator.py`
4. 生成vs2019文件夹
5. 编译release版本
6. 将生成的dll放到ogm-app/modules目录下