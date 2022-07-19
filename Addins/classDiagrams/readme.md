# Class Diagrams
These are generated by [jebbs.plantuml](https://marketplace.visualstudio.com/items?itemName=jebbs.plantuml) for VS code. You can open each one of the `.puml` files and see the structure for yourself or __:open_file_folder:open the [Hymma.Solidworks.Addins.PlantUmlDiagrams.svg](./Hymma.Solidworks.Addins.PlantUMLDiagrams.svg) and see the complete picture__

Although there are multiple ways to regenerate these files automatically using a combinations of github actions and [npm packages](https://github.com/danielyaa5/puml-for-markdown). There will be no attempt to make this happen any soon. As such it is not guaranteed that these diagrams are up-to-date. Regardless they provide a very good understating of the object model in this package.
## Make PlantUML files manually

### Generate the puml files
using [PlantUmlClassDiagramGenerator](https://github.com/pierre3/PlantUmlClassDiagramGenerator#plantumlclassdiagramgenerator)
```
dotnet tool install --global PlantUmlClassDiagramGenerator
```
```
puml-gen InputPath [OutputPath] -dir
```

### Combine all files

```Powershell
#powershell

#will copy all the contents into the clipboard
dir -Recurse -Filter *.puml | Get-Content | clip

code Hymma.Solidworks.Addins.PlantUmlDiagrams.puml

```
and paste the content to the file.

### Save as Svg

1. Install [jebbs.plantuml](https://marketplace.visualstudio.com/items?itemName=jebbs.plantuml) for VS code. 

2. Browse to the top of the main puml file. `Ctrl+Shift+P` > `PlantUml: Export current fie diagrams` > `SVG`