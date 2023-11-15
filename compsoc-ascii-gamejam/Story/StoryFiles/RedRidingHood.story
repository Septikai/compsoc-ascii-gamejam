0;Once upon a time there was a girl who wore a red cape gifted to her by her grandmother.;1
1;One day her mother gave her a basket with wine, and fruits to bring to her grandmother, who lived in a cottage in the woods!;2
2;Her mother warned her not to speak to strangers on the way, and to come straight home.;3
3;You head out through the woods and begin your journey.;4
4;Along the way you see a patch of flowers in various colours.;5
5;Do you pick the flowers?;{yes_2_7@no_-1_6}
6;You look at the flowers and smile before you continue on your way;7
7;You continue walking looking across the trees, and admiring the natural scenery. You keep walking until eventually you come across a split in the path;8
8;both paths will take you to your grandmothers house, however one while safer takes longer, but the faster path is more dangerous.;9
9;Which path do you take?;{safe_-1_10@fast_-1_14}
# Safe path
10;You begin to walk down the safe but longer path. As you walk through you see some stones that look as though you could use them as little weights;11
11;Do you collect a stone?;{yes_0_13@no_-1_12}
12;You don't have enough time and need to keep going to get to granny's. You continue on the path!;13
13;You continue on the path, until eventually you reach the point where the two paths would link up.;-1
# Fast path
14;You begin down the darker path which isn't as smooth, and has some thorns along it.;15
15;As you're walking you accidentally trip over a tree root that is crossing the path and skin your knee.[EFFECT_HP_-1];16
16;You get up and dust yourself off and continue walking taking note to pay more attention;17
17;You hear some branches crack in the woods around you and quickly do a scan, however nothing is there. You continue walking and see a blade stuck into a tree.;18
18;Do you grab the blade?;{yes_3_20@no_-1_19}
19;You decide it's not worth risking getting hurt, or staying on this path any longer, and continue walking until you reach the point where the two paths sink up!;20
20;You are on the final stretch to get to granny's house. You begin walking down the path when suddenly a wolf runs out in front of you blocking your way.;21
21;You have three options. You can 'run' away, 'talk' to the wolf and try to reason with it, or you can 'fight' the wolf and not have to worry about it again;22
22;Which option do you choose?;{run_-1_23@talk_-1_33@fight_-1_25}
# Run
23;You turn around and begin to run away from the wolf. You don't pay attention where you run, anywhere will work as long as it gets you away from the wolf[ROLL_AGI];{win_-1_28@lose_-1_24}
24;You continue to run however the wolf grabs your leg making you fall.;25
25;You kick at it a few times until eventually it releases your leg and you run off.[EFFECT_HP_-4];26
26;Fueled by pure adrenaline you continue to run, until you see the shephard boy at the top of a hill.;27
27;You run towards him and once you reach the top of the hill you sit down, and explain to him what just occured.[LOAD_Story\\StoryFiles\\BoyWhoCriedWolf.story];-1
28;You refuse to turn around to see if you've lost the wolf.;29
29;You make turns when you can to try and disorient it without realizing you're disorienting yourself.;30
30;You simply keep running until eventually you see the shephard boy on a hill.;31
31;You begin to wave your arms at him, while you run until you reach the top of the hill and notice that you have lost the wolf.;32
32;You sit down and explain what has happened...[LOAD_Story\\StoryFiles\\BoyWhoCriedWolf.story];-1
# Talk
33;You stare at the wolf for a moment before you ask what it wants.[ROLL_CHA];{win_-1_34@lose_-1_3333}
34;The wolf stares at you before sighing.;35
35;It apologizes and explains that it intended to get you lost so that you could starve and be an easy dinner.;36
36;However you're simply too kind, and it can't bear harming you.;37
37;Then it proceeds to turn around and run away leaving you shocked.;38
38;You sigh and continue you're walk to granny's where you will give give her the wine and fruits.;39
39;She thanks you and sends you home.;40
40;While on your way home however you hear a beautiful singing voice that you feel compelled to follow.;41
41;You begin to follow it until you reach a tower[LOAD_Story\\StoryFiles\\Rapunzel.story];-1
42;The wolf starts explaining how it was out exploring when it got lost and know it can't find it's den.;43
43;It looks to be a rather young wolf, and so you decide to trust it.;44
44;You begin to help the wolf find it's home asking questions like what it looks like, and any identifying land marks, however the wolf seems to not know anything.;45
45;Eventually however you turn around and the wolf has disappeared.;46
46;You begin to realize you have no idea where you are, and realize you have gotten lost in the woods.;47
47;You attempt to retrace your steps, however you're simply too far into the woods at this point.;48
48;You eventually hear a beautiful singing voice in the distance.;49
49;You decide to follow it hoping you can ask the person how to get back home.[LOAD_Story\\StoryFiles\\Rapunzel.story];-1
# Fight
50;This is a placeholder, the fight is still not implemented;-1