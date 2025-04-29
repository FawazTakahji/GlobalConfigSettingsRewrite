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

                    <expander *context={General}
                              header-padding="0,0,0,16"
                              margin="0,16">
                        <label *outlet="Header"
                               text={#game.title.general} />
                        <lane orientation="vertical">
                            <lane orientation="horizontal">
                                <checkbox label-text={#game.option.autoRun}
                                          is-checked={<>AutoRun}
                                          layout="content 32px" />
                                <checkbox label-text={#game.option.showPortraits}
                                          is-checked={<>ShowPortraits}
                                          layout="content 32px"
                                          margin="16,0" />
                                <checkbox label-text={#game.option.showMerchantPortraits}
                                          is-checked={<>ShowMerchantPortraits}
                                          layout="content 32px" />
                            </lane>

                            <lane orientation="horizontal"
                                  margin="0,16">
                                <checkbox label-text={#game.option.alwaysShowToolHitLocation}
                                          is-checked={<>AlwaysShowToolHitLocation}
                                          layout="content 32px" />
                                <checkbox label-text={#game.option.hideToolHitLocationWhenMoving}
                                          is-checked={<>HideToolHitLocationWhenInMotion}
                                          layout="content 32px"
                                          margin="16,0,0,0" />
                            </lane>

                            <lane orientation="horizontal">
                                <checkbox label-text={#game.option.controllerPlacementTileIndicator}
                                          is-checked={<>ShowPlacementTileForGamepad}
                                          layout="content 32px" />
                                <checkbox label-text={#game.option.pauseWhenGameWindowIsInactive}
                                          is-checked={<>PauseWhenOutOfFocus}
                                          layout="content 32px"
                                          margin="16,0" />
                            </lane>

                            <lane orientation="horizontal"
                                  margin="0,16">
                                <checkbox label-text={#game.option.useControllerStyleMenus}
                                          is-checked={<>SnappyMenus}
                                          layout="content 32px" />
                                <checkbox label-text={#game.option.showAdvancedCraftingInformation}
                                          is-checked={<>ShowAdvancedCraftingInformation}
                                          layout="content 32px"
                                          margin="16,0,0,0" />
                            </lane>

                            <lane orientation="horizontal">
                                <lane orientation="vertical">
                                    <label text={#game.option.gamepadMode} />
                                    <dropdown options={:GamepadModes}
                                              option-format={:GamepadModeFormat}
                                              selected-option={<>GamepadMode}
                                              option-min-width="250" />
                                </lane>

                                <lane orientation="vertical"
                                      margin="16,0">
                                    <label text={#game.option.itemStowing} />
                                    <dropdown options={:StowingModes}
                                              option-format={:StowingModeFormat}
                                              selected-option={<>StowingMode}
                                              option-min-width="250" />
                                </lane>

                                <lane orientation="vertical">
                                    <label text={#game.option.slingshotFireMode} />
                                    <dropdown options={:SlingshotFireModes}
                                              option-format={:SlingshotFireModeFormat}
                                              selected-option={<>UseLegacySlingshotFiring}
                                              option-min-width="300" />
                                </lane>
                            </lane>
                        </lane>
                    </expander>

                    <expander *context={Sound}
                              header-padding="0,0,0,16">
                        <label *outlet="Header"
                               text={#game.title.sound} />
                        <lane orientation="vertical">
                            <lane orientation="vertical">
                                <label text={#game.option.musicVolume} />
                                <slider track-width="200"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>MusicVolume} />
                            </lane>

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.soundVolume} />
                                <slider track-width="200"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>SoundVolume} />
                            </lane>

                            <lane orientation="vertical">
                                <label text={#game.option.ambientVolume} />
                                <slider track-width="200"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>AmbientVolume} />
                            </lane>

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.footstepVolume} />
                                <slider track-width="200"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>FootstepVolume} />
                            </lane>

                            <lane orientation="vertical">
                                <label text={#game.option.fishingBiteSound} />
                                <dropdown options={:FishingBiteSounds}
                                          option-format={:FishingBiteSoundFormat}
                                          selected-option={<>FishingBiteSound}
                                          option-min-width="250" />
                            </lane>

                            <checkbox label-text={#game.option.dialogueTypingSound}
                                      is-checked={<>DialogueTypingSound}
                                      layout="content 32px"
                                      margin="0,16" />

                            <checkbox label-text={#game.option.muteAnimalSounds}
                                      is-checked={<>MuteAnimalSounds}
                                      layout="content 32px" />
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