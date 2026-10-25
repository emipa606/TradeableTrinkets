# GitHub Copilot Instructions for Tradeable Trinkets (Continued) Mod

## Mod Overview and Purpose

The Tradeable Trinkets (Continued) mod is an update of the Captain Muscles mod, adding four new types of craftable trinket items to the RimWorld game. These trinkets can be used as a new type of joy item and trinkets of above-average quality can be sold for a profit. The mod aims to enhance the crafting system by introducing new items that can add joy to pawns and provide potential profit for players.

## Key Features and Systems

- **Trinket Items**: The mod adds four new trinket items: Doll, Totem, Rim Boy, and Tablet. Each trinket requires specific resources and can be crafted at different workbenches, using different skills.
- **Joy Items**: Trinkets can be used as a joy item by pawns, who will pick them up and play with them. This adds a new form of entertainment for pawns in the game.
- **Profit System**: Good quality trinkets can be sold for a profit, as their value is designed so that they will sell for the same price as the ingredients, not including trader skill modifiers. A crafter of skill 12+ is needed to reliably make a profit.
- **Stack Size**: Trinkets stack up to 25 unless modified by another mod.

## Coding Patterns and Conventions

- **Harmony Patching**: The mod uses the Harmony library for patching vanilla RimWorld code. Harmony patching allows the mod to modify existing game functionality without altering the original game files.
- **Job Drivers and Joy Givers**: The mod introduces new job drivers and joy givers to handle the interaction with trinkets. These classes define the behavior of pawns when interacting with trinkets.
- **XML Definitions**: The mod uses XML files to define new game elements such as job definitions, joy giver definitions, and thing definitions. These XML files are integrated into the game to create the new trinket items.
- **Stat Extensions**: The mod uses stat extensions to modify the behavior of existing game stats. For example, the `StatExtension_GetStatValue` class is used to modify the value of trinkets based on their quality.

## XML Integration

The mod uses XML files to define new game elements such as job definitions, joy giver definitions, and thing definitions. These XML files are integrated into the game to create the new trinket items. The following XML files are used in the mod:

- **Jobs_Misc.xml**: Defines new job definitions for interacting with trinkets.
- **JoyGivers.xml**: Defines new joy giver definitions for pawns to use trinkets as a joy item.
- **JoyKinds.xml**: Defines new joy kind definitions for the trinket joy item.
- **ThingCategories.xml**: Defines new thing category definitions for the trinket items.
- **Items_Luxury.xml**: Defines new thing definitions for the trinket items.

## Harmony Patching

The mod uses the Harmony library for patching vanilla RimWorld code. Harmony patching allows the mod to modify existing game functionality without altering the original game files. The following Harmony patches are used in the mod:

- **JobDriver_PlayWithTrinket.cs**: Patches the `JobDriver_PlayWithTrinket` class to handle the interaction with trinkets. The patch modifies the behavior of the job driver to make pawns interact with trinkets as a joy item.
- **JoyGiver_PlayWithTrinket.cs**: Patches the `JoyGiver_PlayWithTrinket` class to handle the interaction with trinkets. The patch modifies the behavior of the joy giver to make pawns use trinkets as a joy item.
- **StatExtension_GetStatValue.cs**: Patches the `StatExtension_GetStatValue` class to modify the behavior of existing game stats. The patch modifies the value of trinkets based on their quality.

## Suggestions for Copilot

- **Job Drivers and Joy Givers**: When implementing new job drivers and joy givers, use the existing ones in the game as a reference. This will help you understand the behavior and functionality of these classes.
- **XML Definitions**: When defining new game elements using XML, make sure to follow the existing XML file structures in the game. This will help you avoid errors and ensure that your new elements are integrated correctly.
- **Harmony Patching**: When using Harmony patching, make sure to understand the behavior of the original game code that you are patching. This will help you create patches that modify the behavior in the desired way without causing errors.
- **Code Comments**: When writing code, make sure to include comments that explain the behavior and functionality of the code. This will help other modders understand your code and make it easier to maintain in the future.

## Conclusion

The Tradeable Trinkets (Continued) mod is a great example of a well-structured and well-documented mod that adds new functionality to the RimWorld game. By following the coding patterns and conventions used in this mod, you can create your own mods that integrate seamlessly with the game and provide new and exciting gameplay experiences.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

