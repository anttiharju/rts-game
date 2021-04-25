: Generates UML diagram and opens it as a .png.
: 
: DEPENCIES:
: https://github.com/pierre3/PlantUmlClassDiagramGenerator
: Has to be installed locally. Follow the instructions in the repository.
: https://plantuml.com/
: MIT-licensed version is included, but you might need things like java.
puml-gen ./Assets/ ./Documentation/Generated/ -dir -createAssociation -allInOne
java -jar ./Tools/PlantUML/plantuml.jar ./Documentation/Generated/include.puml
start ./Documentation/Generated/include.png