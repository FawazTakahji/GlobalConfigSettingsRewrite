<lane orientation="vertical"
      horizontal-content-alignment="middle">
    <banner background-border-thickness="48,0"
            padding="12"
            text={#title.globalSettings}
            background={@Mods/StardewUI/Sprites/BannerBackground} />
    <frame margin="0,16,0,0"
           padding="32,24"
           background={@Mods/StardewUI/Sprites/ControlBorder}>
        <lane orientation="vertical">
            <scrollable peeking="128">
                <lane orientation="vertical"
                      layout="stretch content">
                    <expander *context={ModSettings}
                              header-padding="0,0,0,16">
                        <label *outlet="Header"
                               text={#title.modSettings} />
                        <lane orientation="vertical">
                            <lane orientation="horizontal">
                                <checkbox label-text={#setting.applyOnCreation}
                                          tooltip={#setting.applyOnCreation.tooltip}
                                          is-checked={<>ApplyOnCreation}
                                          layout="content 32px" />
                                <checkbox label-text={#setting.applyOnLoad}
                                          tooltip={#setting.applyOnLoad.tooltip}
                                          is-checked={<>ApplyOnLoad}
                                          layout="content 32px"
                                          margin="16,0" />
                            </lane>
                            <lane orientation="horizontal"
                                  vertical-content-alignment="middle"
                                  margin="0,16,0,0">
                                <checkbox label-text={#setting.whitelist}
                                          is-checked={<>UseWhitelist}
                                          layout="content 32px" />
                                <button layout="content"
                                        margin="16,0"
                                        click=|^OpenSaveList("Whitelist")|>
                                    <image sprite={@Mods/StardewUI/Sprites/SmallUpArrow } />
                                </button>

                                <checkbox label-text={#setting.blacklist}
                                          is-checked={<>UseBlacklist}
                                          layout="content 32px" />
                                <button layout="content"
                                        margin="16,0,0,0"
                                        click=|^OpenSaveList("Blacklist")|>
                                    <image sprite={@Mods/StardewUI/Sprites/SmallUpArrow } />
                                </button>
                            </lane>
                            <label horizontal-alignment="end" text={#paragraph.filters} />
                        </lane>
                    </expander>
                </lane>
            </scrollable>

            <spacer layout="0px 16px" />

            <lane orientation="horizontal">
                <button text={#button.reset}
                        click=|Reset()| />
                <spacer layout="stretch 0px" />

                <button text={#button.cancel}
                        click=|Cancel()| />
                <spacer layout="16px 0px" />

                <button text={#button.save}
                        click=|Save()| />
            </lane>
        </lane>
    </frame>
</lane>