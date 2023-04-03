# Keep Talking and Nobody Explodes Assistant

An assistant to help you defuse modules for the game [Keep Talking and Nobody Explodes](https://keeptalkinggame.com/) using [Speech Recognition](https://docs.microsoft.com/en-us/dotnet/api/system.speech.recognition.speechrecognitionengine) and [Speech Synthesis](https://docs.microsoft.com/en-us/dotnet/api/system.speech.synthesis.speechsynthesizer).

## Before you give it a go, make sure that:

+ **You are using your default microphone.** The program automatically sets the input to your default audio input device.
+ **You have installed voices for English.** Microsoft David and Microsoft Zira should appear by default. If they don't, then you might not have installed voice for English.
+ **You are using headphones.** You can use speakers too, but you might want to lower the volume, as it might interfere with the audio inputs (the bot can hear itself).
+ **You try different english accents.** This is not my fault. I rarely struggle with my Greek accent, but I haven't tried other accents.

## Reasons for forking

+ Switch to a modern version of .NET
+ Rewrite core to allow for easier extensibility
+ Replace "bomb check" to account for setup mistakes
+ Streamline input grammar
+ Speed up the input of some modules

## Initializing the Bomb's Properties

Before defusing any module, you must first configure the bomb state. The properties that matter are:

| Property                            | Voice Command                                                       |
|-------------------------------------|---------------------------------------------------------------------|
| Number of batteries                 | Set batteries <0-6 \| none \| more than two>                        |
| CAR indicator                       | Set car <yes \| no \| true \| false \| lit \| unlit \| on \| off>   |
| FRK indicator                       | Set freak <yes \| no \| true \| false \| lit \| unlit \| on \| off> |
| Parallel port                       | Set port <yes \| no \| true \| false \| lit \| unlit \| on \| off>  |
| Vowel in serial number              | Set vowel <yes \| no \| true \| false \| lit \| unlit \| on \| off> |
| Last digit of serial number is even | Set digit <even \| odd>                                             |

These properties can be changed at any time once the assistant has been set up along with:

| Property                            | Voice Command     |
|-------------------------------------|-------------------|
| Strikes                             | Set strikes <0-2> |

You can also skip this section if you want, by clicking the **"Random Bomb"** button.
This button will initialize a bomb with completely random properties.
This is likely to be useful, if you want to disarm a module that has nothing to do with the bomb's properties (e.g. Keypad or Memory).

## Modules

![Example Complicated](https://static.wikia.nocookie.net/ktane/images/a/a5/Complicated_Wires.jpg/revision/latest)

### Complicated Wires (*"Defuse Complicated"*)

After stating the wire's colors, you must say if there is any indicator afterwards (a light and/or a star or nothing).

Example:

+ **"White Star"**
+ **"White Star"**
+ **"Blue Light"**
+ **"Blue and White Light"**
+ **"Red Light"**
+ **"Blue and White Nothing"**

---

![Example Keypad](https://static.wikia.nocookie.net/ktane/images/6/6f/Keypad.png/revision/latest)

### Keypad (*"Defuse Keypad"*)

State the symbols in any order. **After you state a symbol, wait until the assistant repeats it and says "next".**

Example:

+ **"Lambda"**
+ **"Kitty"**
+ **"At"**
+ **"Reverse C"**

#### Symbols

| | | | | | |
|:-:|:-:|:-:|:-:|:-:|:-:|
| ![][keypad:balloon] | ![][keypad:euro] | ![][keypad:copyright] | ![][keypad:six] | ![][keypad:pitchfork] | ![][keypad:six] |
| Balloon | Euro | Copyright | Six | Pitchfork | Six |
| ![][keypad:at] | ![][keypad:balloon] | ![][keypad:pumpkin] | ![][keypad:paragraph] | ![][keypad:smileyface] | ![][keypad:euro] |
| At | Balloon | Pumpkin | Paragraph | Smiley face | Euro |
| ![][keypad:lambda] | ![][keypad:reversec] | ![][keypad:pigtail] | ![][keypad:bt] | ![][keypad:bt] | ![][keypad:puzzle] |
| Lambda | Reverse C | Pigtail | Bt | Bt | Puzzle |
| ![][keypad:lightning] | ![][keypad:pigtail] | ![][keypad:doublek] | ![][keypad:kitty] | ![][keypad:c] | ![][keypad:ash] |
| Lightning | Pigtail | Double K | Kitty | C | Ash |
| ![][keypad:kitty] | ![][keypad:emptystar] | ![][keypad:three] | ![][keypad:doublek] | ![][keypad:paragraph] | ![][keypad:pitchfork] |
| Kitty | Empty star | Three | Double K | Paragraph | Pitchfork |
| ![][keypad:curlyh] | ![][keypad:curlyh] | ![][keypad:lambda] | ![][keypad:questionmark] | ![][keypad:dragon] | ![][keypad:reversen] |
| Curly H | Curly H | Lambda | Question mark | Dragon | Reverse N |
| ![][keypad:reversec] | ![][keypad:questionmark] | ![][keypad:emptystar] | ![][keypad:smileyface] | ![][keypad:fullstar] | ![][keypad:omega] |
| Reverse C | Question mark | Empty star | Smiley face | Full star | Omega |

---

![Example Maze](https://static.wikia.nocookie.net/ktane/images/a/af/ModuleMaze.jpg/revision/latest)

### Maze (*"Defuse Maze"*)

First, state the coordinates (column,row) of any of the green circles, then the white square and then the red triangle.
(1,1) is the top left corner, (6,6) the bottom right corner.
After that, using BFS, the assistant will tell you which path to follow (Up, Down, etc.).

Example:

+ **"1 1"** or **"4 1"**
+ **"1 1"**
+ **"3 2"**

---

![Example Memory](https://static.wikia.nocookie.net/ktane/images/5/55/Memory.jpg/revision/latest/scale-to-width-down/225)

### Memory (*"Defuse Memory"*)

State all five numbers that you see, starting with the display and then going sequentially left-to-right.

Example:

+ **"4 2 4 3 1"**

---

![Example Morse](https://static.wikia.nocookie.net/ktane/images/e/ee/Morse_Code.jpg/revision/latest)
  
### Morse Code (*"Defuse Morse"*)

Starting from the first letter, the assistant will sequentially ask you to state the morse code with dots/shorts and dashes/longs.

---

![Example Password](https://static.wikia.nocookie.net/ktane/images/6/64/Password.jpg/revision/latest/scale-to-width-down/225)

### Password (*"Defuse Password"*)

For each column the assistant asks for, state all 6 letters by saying the letter itself or by using the [military alphabet](https://en.wikipedia.org/wiki/NATO_phonetic_alphabet).

---

![Example Simon](https://static.wikia.nocookie.net/ktane/images/9/90/Simon.png/revision/latest)

### Simon Says (*"Defuse Simon"*)

State the color that flashes **last**.

---

![Example Button](https://static.wikia.nocookie.net/ktane/images/c/cf/Button.png/revision/latest)

### The Button (*"Defuse Button"*)

State the button color and then the label.
If the button needs to be held, state the color of the stripe and then the word "stripe".

Example:

+ **"White Hold"**
+ **"Yellow Stripe"**

---

![Example WIOF](https://static.wikia.nocookie.net/ktane/images/9/92/Who%27s_on_First.png/revision/latest)

### Who's On First (*"Defuse Who Is On First"*)

Say all words as you normally would except:

+ [when the display is blank] → **"it is blank"**
+ C → **"c letter"**
+ CEE → **"charlie echo echo"**
+ LEED → **"el ee ee dee"**
+ READ → **"read noun"**
+ RED → "**red color"**
+ REED → **"ar ee ee dee"**
+ THEIR → **"their pronoun"**
+ THEY'RE → **"they're apostrophe"**
+ U → **"u letter"**
+ UH HUH → **"u h space h u h"**
+ UH UH → **"u h space u h"**
+ UHHH → **"u h h h" (spell the letters)**
+ UR → **"u r letters"**
+ WHAT? → **"what questionmark"**
+ YOU'RE → **"you're apostrophe"**
+ YOUR → **"your pronoun"**

Example:

+ **"Nothing"**

---

![Example Sequence](https://static.wikia.nocookie.net/ktane/images/2/23/Wire_Sequence.jpg/revision/latest)

### Wire Sequence (*"Defuse Sequence"*)

State the color of the wire and then the letter that it's connected to.
The letter has to be pronounced as "Alpha", "Bravo" or "Charlie".

Example:

+ **"Blue Alpha"**
+ **"Blue Charlie"**

---

![Example Wires](https://static.wikia.nocookie.net/ktane/images/3/39/Wires.png/revision/latest)

### Wires (*"Defuse Wires"*)

State the colors of the wires, from top to bottom, followed by "done".

Example: **"Yellow White Red Black Done"**

## Needy Modules

![Example Knob](https://static.wikia.nocookie.net/ktane/images/9/95/NeedyKnob_Manual2_down2.png/revision/latest/scale-to-width-down/225)

### The Knob (*"Defuse Knob"*)

Using "off" for unlit and "on" for lit, spell the six lights that you see (three on the upper left and three on lower left).

Example:

+ **"off on on on on on"**

[keypad:balloon]: resources/balloon.png "balloon"
[keypad:at]: resources/at.png "at"
[keypad:lambda]: resources/lambda.png "lambda"
[keypad:lightning]: resources/lightning.png "lightning"
[keypad:kitty]: resources/kitty.png "kitty"
[keypad:curlyh]: resources/curlyh.png "curlyh"
[keypad:reversec]: resources/reversec.png "reversec"
[keypad:euro]: resources/euro.png "euro"
[keypad:pigtail]: resources/pigtail.png "pigtail"
[keypad:emptystar]: resources/emptystar.png "emptystar"
[keypad:questionmark]: resources/questionmark.png "questionmark"
[keypad:copyright]: resources/copyright.png "copyright"
[keypad:pumpkin]: resources/pumpkin.png "pumpkin"
[keypad:doublek]: resources/doublek.png "doublek"
[keypad:three]: resources/three.png "three"
[keypad:six]: resources/six.png "six"
[keypad:paragraph]: resources/paragraph.png "paragraph"
[keypad:bt]: resources/bt.png "bt"
[keypad:smileyface]: resources/smileyface.png "smileyface"
[keypad:pitchfork]: resources/pitchfork.png "pitchfork"
[keypad:c]: resources/c.png "c"
[keypad:dragon]: resources/dragon.png "dragon"
[keypad:fullstar]: resources/fullstar.png "fullstar"
[keypad:puzzle]: resources/puzzle.png "puzzle"
[keypad:ash]: resources/ash.png "ash"
[keypad:reversen]: resources/reversen.png "reversen"
[keypad:omega]: resources/omega.png "omega"
