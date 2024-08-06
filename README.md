# Armor-Multiverse
A time-lapse utility for Legacy Halo: Reach TU1

# Why does this exist?
Leading up to the release of Halo Infinite, 343 Industries unveiled the [Multiplayer Overview](https://youtu.be/n-O7OuliQRY?si=qlWMteWaNh04ijBQ&t=403) video. During the armor customization breakdown Ryan Paradis mentioned; "The body of customization content that we have on day one ensures that there will be millions of customization combinations for spartans on the battlefield. That includes armor coatings, armor emblems, various armor effects and down to the individual armor pieces." 

I thought this quote was silly because if you did the math, yeah they're technically right (and I'm too lazy to check how much they actually had at launch), but halo titles that released over a decade prior also had millions of customization combinations, well actually Halo: Reach has a lot more, approximately 3.99x10^27 (3,991,384,982,303,421,081,303,244,800) combinations.

> (Three septillion, nine hundred ninety-one sextillion, three hundred eighty-four quintillion, nine hundred eighty-two quadrillion, three hundred three trillion, four hundred twenty-one billion, eighty-one million, three hundred three thousand, two hundred forty-four thousand, eight hundred.)

77 (Helmet) × 21 (Left shoulder) × 21 (Right shoulder) × 23 (Chest) × 6 (Wrist) × 6 (Utility) × 5 (Visor color) × 4 (Knee guards) × 7 (Armor effect) × 13 (Firefight voice) × 36 (Primary color) × 36 (Secondary color) × 36 (Emblem primary color) × 36 (Emblem secondary color) × 36 (Emblem background color) × 117 (Emblem foreground) × 64 (emblem background) × (emblem toggle) 2 = 3.99x10^27

Then I wondered how long would it take to wear every possible armor combination...

### Approaching the heat death of the universe
- 3.99x10^27 (Total combinations) / 0.01 (Seconds) = 3.99x10^29
- 3.99x10^29 (Total combinations) / 31536000 (Seconds in a year) = 1.265x10^22 
> 12,650,000,000,000,000,000,000 years...

So, looping through every combination at a rate of 0.01 seconds per combination would take approximately twelve sextillion six hundred fifty quintillion years. That's an incredibly vast amount of time – far longer than the current estimated age of the universe! Since my Xbox 360 probably won't last that long, to cut down on time I'll only loop through visible armor selections available in the main menu.

After reducing the selection to a more reasonable amount by excluding colors, emblems, armor effects, and firefight voices etc. We're left with 267,888,660 possibilities and only 1.033 months of total time spent to swap every combination.

# Prerequisites
You'll need a few things to get this running.
- [.NET Desktop Runtime 6.0.25](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [.NET SDK 6.0.417](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

You're on your own finding these.
- A Jtag/RGH (Modded Xbox 360)
- JRPC.xex plugin
- JRPC.dll
- xbdm.xex plugin
- xdevkit.dll
- Halo: Reach running Title Update 1

# Closing
20.9 TB time-lapse compressed into a 50mb gif coming soon...
