
[![GitHub](https://img.shields.io/github/license/keenanwoodall/Deform.svg)](https://github.com/AlienFruit/AlienFruit.Otml/blob/master/LICENSE.MIT)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue.svg)](https://github.com/AlienFruit/AlienFruit.Otml)


## FluentConsole

### Nuget
|  Package name | Package version            |
|---------------|----------------------------|
|    AlienFruit.FluentConsole      |    [![Nuget](https://img.shields.io/nuget/v/AlienFruit.FluentConsole.svg)](https://www.nuget.org/packages/AlienFruit.FluentConsole)   |

**FluentConsole** is a simple standart console wrapper, which has a fluent interface.

Probably many people have noticed that the code of change color in the console is looking a bit bulky.

```C#
Console.WriteLine("This is a text");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("This is a green text");
Console.BackgroundColor = ConsoleColor.Red;
Console.WriteLine("his is a green text with red background");
Console.ResetColor();
Console.WriteLine("This is a white text");
```

An alternative approach, with use of FluentConsole

```C#
FConsole.WriteLine("This is a text")
    .Color(ConsoleColor.Green).WriteLine("This is a green text")
    .BackgroundColor(ConsoleColor.Red).WriteLine("This is a green text with red background")
    .ResetColors()
    .WriteLine("This is a white text");
```
Or:
```C#
FConsole.WriteLine("This is a text")
    .Color(ConsoleColor.Green).WriteLine("This is a green text")
    .BackgroundColor(ConsoleColor.Red).WriteLine("This is a green text with red background")
FConsole.WriteLine("This is a white text");
```

## FluentConsole.AsciiArt

### Nuget
|  Package name | Package version            |
|---------------|----------------------------|
|    AlienFruit.FluentConsole.AsciiArt  | [![Nuget](https://img.shields.io/nuget/v/AlienFruit.FluentConsole.AsciiArt.svg)](https://www.nuget.org/packages/AlienFruit.FluentConsole.AsciiArt) |

**FluentConsole.AsciiArt** is a **FluentConsole** extension by which an ASCII picture can be painted from a file.

Use the following code for painting a demo picture.
```C#
FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.RainbowPukeSkull);
```

Next, you will see the demo picture by xero. You can see all his works on http://0w.nz.

<div align="center">
    <img src="https://raw.githubusercontent.com/AlienFruit/AlienFruit.FluentConsole/master/design/Images/RainbowPukeSkull.png">
</div>

There are two methods for drawing your pictures from a file.

```C# 
Draw(string pictureFile) // draw from specified file path
```
and
```C#
Draw(Stream stream) //draw from stream
```
Example:
```C#
FConsole.GetInstance().GetAsciiArtBuilder().Draw("yourAsciiPicture.otml");
```

The picture file has OTML data format. 

You can get more information about OTML on
https://github.com/AlienFruit/AlienFruit.Otml

### ASCII picture data structure

```python

# This is a mandatory object which contains picture chars.
# @Source is an object which contains a multiline text, you can read more about an Otml multiline text on:
# https://github.com/AlienFruit/AlienFruit.Otml/blob/master/docs/en/specification.md#multiline-values
@source
	"      -/////+-	     " +
	" `-::+d/:--:/d+::-` " +
	"//`  o+      ++  `//" +
	"s   :Ns`    `sN-   s" +
	"+:/oo++//++///+o+:/+" +
	"+yo`    `ys`    `oy/" +
	"s:/      oo      /:s" +
	"+///:--:ohho:--:///+" +
	" `::/os``````so//:` " +
	"      -/:--:/-      "

# this is an optional object
@style
	background : default	# background color of the all picture
	foreground : green	# foreground color of tho all picture
	margin-top : 2		# top margin, there are 2 empty text lines upper the picture
	margin-bottom : 2	# bottom margin, there are 2 empty text lines down below the picture
	margin-left : 2		# left margin, there are 2 empty chars on the picture left


# for color text selection are used the spetial methods "@select"

# detailed method
@select
	row : 0			# row number
	start : 6		# start selection
	length : 8		# selection length
	foreground : darkGreen	# foreground color
	background : default 	# background (optional)

# All available colors:
# black
# darkBlue
# darkGreen
# darkCyan
# darkRed
# darkMagenta
# darkYellow
# gray
# darkGray
# blue
# green
# cyan
# red
# magenta
# yellow
# white
# default - default console color

# or short method where
# 1 - row number, 1 - start selection, 18 - selection length, 
# red - foreground color,
# default - background color (optional)
@select	: 1, 1, 18, darkGreen, default 

# or short method in other style
@select	
    2			# row number
    0			# start selection
    20			# selection length
    darkGreen,		# foreground color
    default		# background (optional)


@select	: 3, 0, 20, darkGreen
@select	: 4, 0, 20, darkGreen
@select	: 5, 0, 20, darkGreen
@select	: 6, 0, 20, darkGreen
@select	: 7, 0, 20, darkGreen
@select	: 8, 1, 18, darkGreen
@select	: 9, 6, 8,  darkGreen
    
```
