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
                            <checkbox label-text={#setting.applyOnCreation}
                                      tooltip={#setting.applyOnCreation.tooltip}
                                      is-checked={<>ApplyOnCreation}
                                      layout="content 32px" />

                            <checkbox label-text={#setting.applyOnLoad}
                                      tooltip={#setting.applyOnLoad.tooltip}
                                      is-checked={<>ApplyOnLoad}
                                      layout="content 32px"
                                      margin="0,16" />

                            <lane orientation="horizontal"
                                  vertical-content-alignment="middle">
                                <checkbox label-text={#setting.whitelist}
                                          is-checked={<>UseWhitelist}
                                          layout="content 32px" />
                                <button layout="content"
                                        margin="16,0,0,0"
                                        click=|^OpenSaveList("Whitelist")|>
                                    <image sprite={@Mods/StardewUI/Sprites/SmallUpArrow } />
                                </button>
                            </lane>

                            <lane orientation="horizontal"
                                  vertical-content-alignment="middle"
                                  margin="0,16,0,5">
                                <checkbox label-text={#setting.blacklist}
                                          is-checked={<>UseBlacklist}
                                          layout="content 32px" />
                                <button layout="content"
                                        margin="20,0,0,0"
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
                            <checkbox label-text={#game.option.autoRun}
                                      is-checked={<>AutoRun}
                                      layout="content 32px" />

                            <checkbox label-text={#game.option.showPortraits}
                                      is-checked={<>ShowPortraits}
                                      layout="content 32px"
                                      margin="0,16" />

                            <checkbox label-text={#game.option.showMerchantPortraits}
                                      is-checked={<>ShowMerchantPortraits}
                                      layout="content 32px" />

                            <checkbox label-text={#game.option.alwaysShowToolHitLocation}
                                      is-checked={<>AlwaysShowToolHitLocation}
                                      layout="content 32px"
                                      margin="0,16" />

                            <checkbox label-text={#game.option.hideToolHitLocationWhenMoving}
                                      is-checked={<>HideToolHitLocationWhenInMotion}
                                      layout="content 32px" />

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.gamepadMode} />
                                <dropdown options={:GamepadModes}
                                          option-format={:GamepadModeFormat}
                                          selected-option={<>GamepadMode}
                                          option-min-width="300" />
                            </lane>

                            <lane orientation="vertical">
                                <label text={#game.option.itemStowing} />
                                <dropdown options={:StowingModes}
                                          option-format={:StowingModeFormat}
                                          selected-option={<>StowingMode}
                                          option-min-width="300" />
                            </lane>

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.slingshotFireMode} />
                                <dropdown options={:SlingshotFireModes}
                                          option-format={:SlingshotFireModeFormat}
                                          selected-option={<>UseLegacySlingshotFiring}
                                          option-min-width="300" />
                            </lane>

                            <checkbox label-text={#game.option.controllerPlacementTileIndicator}
                                      is-checked={<>ShowPlacementTileForGamepad}
                                      layout="content 32px" />

                            <checkbox label-text={#game.option.pauseWhenGameWindowIsInactive}
                                      is-checked={<>PauseWhenOutOfFocus}
                                      layout="content 32px"
                                      margin="0,16" />

                            <checkbox label-text={#game.option.useControllerStyleMenus}
                                      is-checked={<>SnappyMenus}
                                      layout="content 32px" />

                            <checkbox label-text={#game.option.showAdvancedCraftingInformation}
                                      is-checked={<>ShowAdvancedCraftingInformation}
                                      layout="content 32px"
                                      margin="0,16,0,0" />
                        </lane>
                    </expander>

                    <expander *context={Sound}
                              header-padding="0,0,0,16">
                        <label *outlet="Header"
                               text={#game.title.sound} />
                        <lane orientation="vertical">
                            <lane orientation="vertical">
                                <label text={#game.option.musicVolume} />
                                <slider track-width="300"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>MusicVolume} />
                            </lane>

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.soundVolume} />
                                <slider track-width="300"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>SoundVolume} />
                            </lane>

                            <lane orientation="vertical">
                                <label text={#game.option.ambientVolume} />
                                <slider track-width="300"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>AmbientVolume} />
                            </lane>

                            <lane orientation="vertical"
                                  margin="0,16">
                                <label text={#game.option.footstepVolume} />
                                <slider track-width="300"
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
                                          option-min-width="300" />
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

                    <expander *context={Graphics}
                              header-padding="0,0,0,16"
                              margin="0,16">
                        <label *outlet="Header"
                               text={#game.title.graphics} />
                        <lane orientation="vertical">
                            <lane orientation="vertical">
                                <label text={#game.option.menuBackgrounds} />
                                <dropdown options={:Backgrounds}
                                          option-format={:BackgroundFormat}
                                          selected-option={<>MenuBackgrounds}
                                          option-min-width="300" />
                            </lane>

                            <checkbox label-text={#game.option.vsync}
                                      is-checked={<>Vsync}
                                      layout="content 32px"
                                      margin="0,16" />

                            <lane orientation="vertical">
                                <label text={#game.option.uiScale} />
                                <slider track-width="300"
                                        min="75"
                                        max="150"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>UiScale} />
                            </lane>

                            <checkbox label-text={#game.option.lockToolbar}
                                      is-checked={<>LockToolbar}
                                      layout="content 32px"
                                      margin="0,16" />

                            <lane orientation="vertical">
                                <label text={#game.option.zoomLevel} />
                                <slider track-width="300"
                                        min="75"
                                        max="200"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>ZoomLevel} />
                            </lane>

                            <checkbox label-text={#game.option.zoomButtons}
                                      is-checked={<>ZoomButtons}
                                      layout="content 32px"
                                      margin="0,16" />

                            <lane orientation="vertical">
                                <label text={#game.option.snowTransparency} />
                                <slider track-width="300"
                                        min="0"
                                        max="100"
                                        interval="1"
                                        value-format={:^SliderFormat}
                                        value={<>SnowTransparency} />
                            </lane>

                            <checkbox label-text={#game.option.showFlashEffects}
                                      is-checked={<>ShowFlashEffects}
                                      layout="content 32px"
                                      margin="0,16" />

                            <checkbox label-text={#game.option.useHardwareCursor}
                                      is-checked={<>UseHardwareCursor}
                                      layout="content 32px" />
                        </lane>
                    </expander>

                    <expander *context={Controls}
                              header-padding="0,0,0,16">
                        <label *outlet="Header"
                               text={#game.title.controls} />
                        <lane orientation="vertical">
                            <checkbox label-text={#game.option.controllerRumble}
                                      is-checked={<>ControllerRumble}
                                      layout="content 32px" />

                            <checkbox label-text={#game.option.invertToolbarScrollDirection}
                                      is-checked={<>InvertToolbarScrollDirection}
                                      layout="content 32px"
                                      margin="0,16" />

                            <button text={#other.reset-controls}
                                    click=|^ResetControls()| />

                            <control label={#game.option.checkDoAction}
                                     keybind={<>CheckDoAction}
                                     margin="0,16" />

                            <control label={#game.option.useTool}
                                     keybind={<>UseTool} />

                            <control label={#game.option.accessMenu}
                                     keybind={<>AccessMenu}
                                     margin="0,16" />

                            <control label={#game.option.accessJournal}
                                     keybind={<>AccessJournal} />

                            <control label={#game.option.accessMap}
                                     keybind={<>AccessMap}
                                     margin="0,16" />

                            <control label={#game.option.moveUp}
                                     keybind={<>MoveUp} />

                            <control label={#game.option.moveLeft}
                                     keybind={<>MoveLeft}
                                     margin="0,16" />

                            <control label={#game.option.moveDown}
                                     keybind={<>MoveDown} />

                            <control label={#game.option.moveRight}
                                     keybind={<>MoveRight}
                                     margin="0,16" />

                            <control label={#game.option.chatBox}
                                     keybind={<>ChatBox} />

                            <control label={#game.option.emoteMenu}
                                     keybind={<>EmoteMenu}
                                     margin="0,16" />

                            <control label={#game.option.run}
                                     keybind={<>Run} />

                            <control label={#game.option.shiftToolbar}
                                     keybind={<>ShiftToolbar}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot1}
                                     keybind={<>InventorySlot1} />

                            <control label={#game.option.inventorySlot2}
                                     keybind={<>InventorySlot2}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot3}
                                     keybind={<>InventorySlot3} />

                            <control label={#game.option.inventorySlot4}
                                     keybind={<>InventorySlot4}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot5}
                                     keybind={<>InventorySlot5} />

                            <control label={#game.option.inventorySlot6}
                                     keybind={<>InventorySlot6}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot7}
                                     keybind={<>InventorySlot7} />

                            <control label={#game.option.inventorySlot8}
                                     keybind={<>InventorySlot8}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot9}
                                     keybind={<>InventorySlot9} />

                            <control label={#game.option.inventorySlot10}
                                     keybind={<>InventorySlot10}
                                     margin="0,16" />

                            <control label={#game.option.inventorySlot11}
                                     keybind={<>InventorySlot11} />

                            <control label={#game.option.inventorySlot12}
                                     keybind={<>InventorySlot12}
                                     margin="0,16,0,0" />
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

<template name="control">
    <lane orientation="horizontal"
          vertical-content-alignment="middle"
          margin={&margin}>
        <label text={&label}
               margin="0,0,8,0" />

        <keybind-editor button-height="32"
                        sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.1}
                        editable-type="SingleButton"
                        empty-text={#other.not-set}
                        focusable="true"
                        keybind-list={&keybind} />
    </lane>
</template>