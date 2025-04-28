<lane orientation="vertical">
    <frame background={@Mods/StardewUI/Sprites/ControlBorder}
           padding="32,24"
           layout="content[..400] 40%">
        <list saves={NotSelectedSaves}
              action="Add"
              sprite={@Mods/StardewUI/Sprites/SmallGreenPlus} />
    </frame>

    <frame background={@Mods/StardewUI/Sprites/ControlBorder}
           padding="32,24"
           layout="content[..400] 77%">
        <list saves={SelectedSaves}
              action="Remove"
              sprite={@Mods/StardewUI/Sprites/TinyTrashCan} />
    </frame>

    <lane orientation="horizontal"
          layout="stretch content"
          horizontal-content-alignment="end"
          margin="0,10,0,0">
        <button text={#button.cancel}
                margin="0,0,16,0"
                click=|Cancel()| />
        <button text={#button.ok}
                click=|Ok()| />
    </lane>
</lane>

<template name="list">
    <scrollable layout="stretch">
        <lane orientation="vertical">
            <lane orientation="vertical"
                  focusable="true"
                  *repeat={&saves}>
                <lane orientation="horizontal"
                      layout="stretch content"
                      vertical-content-alignment="middle">
                    <label text={:DisplayName} />

                    <spacer layout="stretch 0px" />

                    <button layout="content"
                            click=|^EditList(&action, FolderName)|>
                        <image sprite={&sprite} />
                    </button>
                </lane>

                <image sprite={@Mods/StardewUI/Sprites/ThinHorizontalDivider}
                       layout="stretch 2px"
                       fit="stretch"
                       margin="0,8" />
            </lane>
        </lane>
    </scrollable>
</template>