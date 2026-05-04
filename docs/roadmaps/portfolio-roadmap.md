# imvdb-playlist-maker portfolio roadmap

## 90-day evidence snapshot
- Commits (90 days): 4
- Files changed (90 days): 127
- Last signal: `25803f6` (4 days ago)
- Top modified areas: `IMVDB` (78), `IMVDB.Gui` (33), `docs` (8), `00_agile` (6)
- Snapshot date: 2026-05-01

## Current posture
- Stack: .NET
- Docs folder: yes
- Roadmap folder: no
- Features docs: yes
- Tests indexed: no (test coverage not visible in this scan)
- Primary active domain:
  - IMVDB client/library behavior
  - IMVDB GUI/desktop shell
  - Playlist and data flow orchestration

## Discovery
- [x] Capture and timestamp recent change signal
- [x] Capture top-level area concentration
- [ ] Add explicit behavior ownership for IMVDB API, GUI, and data contracts
- [ ] Add release gates for playlist export/import and auth paths

## V1 (stability)
- [ ] Document minimum reproducible build/run flow for both IMVDB service and GUI
- [ ] Add deterministic checks for token/auth path failures and recoveries
- [ ] Tighten data-contract checkpoints for playlist ingestion/update
- [ ] Capture baseline UI launch and search/playback smoke checks

## V2 (confidence)
- [ ] Add tests or validation scripts for IMVDB client contract parsing
- [ ] Expand runbook for GUI deployment and user-permission prerequisites
- [ ] Normalize feature notes with explicit payload shape and edge-case handling
- [ ] Add backlog entries for offline/fallback behavior

## V10 (scale)
- [ ] Define versioned IMVDB client contracts and deprecation plan for schema changes
- [ ] Add integration path for shared playlist tooling across repos if adopted
- [ ] Formalize observability for API latency, error, and failure rates
- [ ] Add long-range API/platform compatibility checklist for release planning

## Feature-to-roadmap mapping
- [x] IMVDB API/client modules: `docs/features/sub-module-imvdb.md`
- [x] GUI orchestration: `docs/features/sub-module-imvdb-gui.md`
- [x] Shared contracts/models: `docs/features/imvdb-imvdb-client-shared-shared-contracts-models.md`
- [ ] Blazor client behavior: `docs/features/imvdb-imvdb-client-blazor-webassembly-client.md`
- [ ] ASP.NET Core service behavior: `docs/features/imvdb-imvdb-asp-net-core-server-project.md`
- [x] General capability boundaries: `docs/features/core-capabilities.md`

## Release readiness checklist
- [ ] Start-to-finish playlist sync path executed before merge
- [ ] Failure/retry behavior documented for bad API credentials and payloads
- [ ] Build/run command matrix includes GUI + service path
- [ ] Security/credential behavior has explicit rollback instructions

## Next move
Use V1 to lock API + GUI core reliability first, then move V2 toward contract hardening and V10-level interoperability.
