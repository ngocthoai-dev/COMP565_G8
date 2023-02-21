# COMP565_G8
This project used Zenject, dependency injection framework, as a core to manage the scripts.

# Framework
The framework or project architecture will be started from the _Project directory.

    - Bundles: the folder holds every assets that could be managed by addressables or resources such as prefabs, graphics, audio, etc.
    - Scenes: the scene for building game levels separately. The core is start scene. We almost alwayswork on prefabs -> avoid conflict issues on the scene.
    - Scripts:
        - Business: a project that contains almost interface that can be exposed to any projects.
        - Core:
            - Signal: signal container for event-driven programming, which is implemented by Zenject SignalBus.
            - Game: every specific game login will be run from here.
            - Services: it holds services running through the game for Core project such as network.
            - Modules: this contains the mediators or the controllers for their own view implementation. 
            - Views: the views scripts config for corresponding assets will be stored here.
        - Editor: a project customize unity editor.
        - Extensions: a project give a extendiable manipulation based on object.

The behavior after initialized project will be runned by GameStore Initialize method, which will immediately run into StartSessionScreenController.