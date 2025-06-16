                                               ** # SnakeGame**    
     
This 2D Snake game challenges players to navigate a growing snake, collect food, avoid obstacles, and activate power-ups. It supports single and two-player modes, features score tracking, and ends when a collision occurs or a player wins based on the highest score.    
    
**What I did** : A 2D Snake game in Unity using C#, implementing single and multiplayer modes, power-ups (shield, speed, score boost), collision-based growth, and a UI system with menus and game states using scene management, coroutines, and prefab instantiation for dynamic gameplay elements.          

**GENRE** : Fast-paced,Action,Casual

**Technology**   
              •	Unity   
              •	C#   
              •	UI Framework   
              •	Scene Management   
              •	Input Handling      
              •	Text Rendering   
              •	Coroutines    
              •	Physics & Collision    
              •	Persistent Storage    
     
**Design Pattern**    
    1.	Singleton-like Access (Static Booleans):    
        •	GameIsPaused, scoreG, scoreB are static—used globally across components.    
        •	While simple, this introduces tight coupling and is not recommended for large-scale projects.    
    2.	State Management:    
        •	Game state is implicitly managed using booleans like isGameOver, isShieldActive.    
    3.	Factory-like Instantiation:   
        •	Segments and power-ups are instantiated at runtime via Instantiate() (like a basic factory pattern).   
    4.	Observer Pattern (Partial Use):    
        •	Buttons in LobbyController.cs and GameOver.cs use UnityEvents and listeners (like button.onClick.AddListener), resembling an event-driven observer mechanism.   
    5.	Strategy Pattern (Implied):    
        •	Power-ups alter behavior dynamically at runtime—speed, protection, and score handling, though not abstracted into distinct strategy classes.    

**Images**
![](https://github.com/Sega-13/SnakeGame/blob/Feature-Snake-Co-OPS/2D%20Snake/Images/Screenshot%202025-05-20%20080137.png)![](https://github.com/Sega-13/SnakeGame/blob/Feature-Snake-Co-OPS/2D%20Snake/Images/Screenshot%202025-06-07%20164241.png)![](https://github.com/Sega-13/SnakeGame/blob/Feature-Snake-Co-OPS/2D%20Snake/Images/Screenshot%202025-06-07%20164254.png)![](https://github.com/Sega-13/SnakeGame/blob/Feature-Snake-Co-OPS/2D%20Snake/Images/Screenshot%202025-06-07%20164323.png)![](https://github.com/Sega-13/SnakeGame/blob/Feature-Snake-Co-OPS/2D%20Snake/Images/Screenshot%202025-06-07%20164440.png)   
        
