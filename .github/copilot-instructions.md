# GitHub Copilot Instructions for RimWorld Modding Project: Tradeable Trinkets

## Mod Overview and Purpose
The Tradeable Trinkets mod for RimWorld expands the gameplay experience by introducing a new category of items—trinkets—that can be traded, collected, and used by colonists for joy activities. The goal of this mod is to provide deeper simulation elements and interaction opportunities for players through unique and engaging content.

## Key Features and Systems
- **Trinket Items**: Introduces new tradable items classified as trinkets, which can be crafted or found throughout the game. Trinkets serve as both trade goods and objects for colonist interactions.
- **Joy Activities**: Implement joy activities where colonists can interact with trinkets, enhancing their mood and joy variables.
- **Enhanced Trading**: Integrates seamlessly with the trading system, allowing these items to be bought and sold via traders and caravans.

## Coding Patterns and Conventions
- **Class Naming**: Classes are named using PascalCase. For example, `Trinket`, `TrinketsMod`, and `JobDriver_PlayWithTrinket`.
- **Method Naming**: Methods are typically named using camelCase and are clear and descriptive, such as `FindClosePawn` and `TryGiveJobInternal`.
- **Static Classes**: Used for organizing patch methods, such as `RecipeWorkerCounter_Patches`. Static class conventions follow RimWorld's design patterns for mod extensions and patches.

## XML Integration
- **Defining Trinkets**: XML files define new trinket items, their attributes, and their interaction events. Each trinket's properties like value, rarity, and visual representation are specified in XML definitions.
- **Job Definitions**: XML is used to define jobs related to trinket interaction, customizing how colonists perceive and can engage with these items.

## Harmony Patching
- **Purpose**: Harmony patches are employed to extend or modify base game logic without altering the original source code, ensuring compatibility and ease of maintenance.
- **Implementation**: Patches target specific methods within the game's DLL, such as stats calculations and recipe counting. Example classes like `StatPatches` and `RecipeWorkerCounter_Patches` demonstrate this usage.
- **Patterns**: Patches employ static methods within static classes, following a consistent structure to ensure stability and clarity.

## Suggestions for Copilot
- **Generating Methods**: When creating new methods, ensure clarity in naming to reflect the behavior accurately, such as `CalculateTrinketValue` for determining an item's worth.
- **Adding XML Attributes**: Provide XML suggestions for defining new properties or buffs for trinkets, helping with attribute configuration.
- **Harmony Patches**: Suggest and assist in creating new Harmony patches by correlating them with the applicable RimWorld methods, thus integrating seamlessly with the mod's functionality.
- **Efficiency Improvements**: Encourage Copilot to suggest optimizations in method performance, especially regarding frequent operations like checking pawn proximity or evaluating conditions for joy activities.

By following these guidelines, Copilot can effectively assist in the continued development and refinement of the Tradeable Trinkets mod, making sure it remains robust, enjoyable, and integrated within the larger RimWorld ecosystem.
