# Smack Your Brother
### A small clicker game themed around smacking your brother - Apologies for those who can't relate 🤷‍♂️

As the title and sub-title said, this is a small WPF/C# game that is designed around smacking your brother. The game currently has a big button that signifies "smacking" your brother. I want to eventually add a nice little animation or something here but I'm not creative in the slightest 😩 I also used [Caliburn Micro](https://github.com/Caliburn-Micro/Caliburn.Micro) for the MVVM backing 🙌 👨‍💻

The game also has a number of "upgrades" that can  be purchased to increase the amount of points that are rewarded with each smack. The current upgrades include:

| Upgrade Name | Initial Cost | Reward
|:-------------------:| :-------------:| :---:
| Extra Hand | 20 | 1
| Slipper | 150 | 3
| Shoe | 400 | 5
| Phone Book | 2,000 | 8
| Keyboard | 15,000 | 12
| Stick | 30,000 | 20
| Hammer | 100,000 | 50
| Microwave | 500,000 | 80


As you can see, anyone who wants to play this game is in for the long haul 😅⌛ mharwood.uk

I plan to add more upgrades and maybe more features in the future but for right now, I just want to put this here and see what happens 😇

You can also save and load your game data so that you don't lose your progress. This is stored in a txt file using JSON. 

Here is a GIF of the game being played (Sped up, obviously...) 🕹️: 
![](https://github.com/IT-Delinquent/Smack_Your_Brother/blob/master/Smack%20Your%20Brother.gif)

## UPDATES
| Date | Changes
|:-----:|:-------:|
| 24/01/2020 | Simplified the generic button animation. Added toggle buttons for the smack and purchase sound effects (by the way I added a purchase sound effect 😂 ). Finally, I added a slider for the background music volume.
| 30/12/2019 | What I would call the first fully working program. Finished the styling of stats and sounds. Still have some improvements to add, for example: Muting and changing the volume of game sounds and music
| 14/11/2019 | Added stats popup. Added stats to load and save procedures. Fixed some save and load messages. Half way through styling the stats DataGrid. See commit for full info
