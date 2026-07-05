# Change Note

## TagModbus Client
### 1. NModbus 라이브러리 마이그레이션

- 커스텀 WinModbusLib → NModbus 오픈소스 패키지로 교체
- 클라이언트: `ModbusClient` → `IModbusMaster` + `TcpClient`
- RTU 지원: `NModbus.Serial` 패키지 추가, `SerialPortAdapter` 연결
- `mylibs/` 폴더 삭제 (더 이상 참조 안 함)

### 2. 프로젝트 구조 재편

- `TagModbusLib` 프로젝트 생성 (ModbusTypes, ModbusUtils, MapHelper, ModbusMapLoader)
- 솔루션/프로젝트 이름 변경: WinModbus → TagModbus
  - `TagModbus.sln`, `TagModbusClient.csproj`, `TagModbusLib.csproj`
- 네임스페이스: `WinModbus` → `TagModbus`, `WinModbusLib` → `TagModbusLib`
- ClickOnce 설정 제거, csproj 정리
- `.editorconfig` 추가 (UTF-8 강제)
- `nuget.config` 정리 (패키지 소스/fallback 문제 해결)

### 3. 설정 파일 JSON 전환

- `client-config.xml` → `client-config.json`
- `AppConfig` static 클래스: `AppConfig.Modbus.Ip` 형태로 직접 접근
- `ConfigHelper` 유틸리티로 JSON 로드 분리
- 모든 연결 설정 항목 추가 (mode, connTimeout, responseTimeout 등)
- `FormConnection`에서 [Save] 버튼으로 config 저장

### 4. Modbus Map YAML 지원

- `ModbusMapLoader`: YAML/JSON 자동 감지 로드
- `YamlDotNet` 패키지 추가
- `sample-modbus-map.yaml` 작성 (레지스터 한 줄 정의)
- `SectionDef.CycleTime` 추가 (모니터링 주기)
- DataType 이름 통일: `FLOAT`→`F32`, `DOUBLE`→`F64`, `SHORT`→`S16` 등
- Register key 이름 통일: `REG`→`HREG`, `INREG`→`IREG`

### 5. FormClient UI 개선

- GroupBox 3개로 상단 패널 재구성 (통신 설정 / Modbus 명령 / 조회 옵션)
- 프로토콜 선택: Radio(TCP/RTU) + 설정 팝업(FormConnection) + 연결 상태 TextBox
- `btnConnect` / `btnDisconnect` 분리
- Write 모드: `chkGrpWrite` → Radio 3개 (Single/Multiple/Mixed)
- `writeModbusRegsMixed()` 구현 (연속 주소 그룹핑)
- Display Hex 체크박스 (실시간 포맷 전환)
- dgvModbus 컬럼 정리: Address, RawValue(editable), Converted, Type, Format, Scale, Tag, Description
- DataSource 바인딩 방식으로 성능 개선 (`DataTable` → dgvModbus)
- `DoubleBuffered` 활성화
- 연결 끊김 자동 감지 (`handleConnectionLost`)
- 폰트: Tahoma → Segoe UI

### 6. TagStore + FormTags

- `TagStore` 싱글턴: DataTable 기반 태그 저장소
- `readModbus()` → `TagStore.SetValue()` 연결
- `FormTags` 폼: 태그 목록/검색/값 편집 + Modbus Write 전송
- `MainForm`에서 DockRight로 배치

### 7. TagModbusLib 기능 확장

- `ExceptionCode`, `MaxDataQty` enum 추가
- CRC16 테이블 계산 (`CalculateCRC`, `CheckValidRtuFrame`)
- `ConvertRegistersToUInt32` 추가
- `ConvertRegistersToUInt64` 파라미터 수정 (`ulong[]` → `ushort[]`)
- `ConvertFromRegisters()` / `ConvertToRegisters()` 대칭 쌍 구현
- 데이터 타입 `ushort`/`ulong`/`uint` → `UInt16`/`UInt64`/`UInt32` 통일

### 8. 기타

- log4net 경로: `Application.StartupPath` 기준으로 수정
- `config, maps` 폴더: 빌드 출력에 `CopyToOutputDirectory` 설정
- DockPanelSuite 3.x 테마 설정 (`VS2015BlueTheme`)
- 인코딩 깨짐 복구 (EUC-KR → UTF-8), 인코딩 깨짐이 반복되어서 모든 주석 영어로 재작성
- float 소수점 포맷: `"0.#####"` (trailing zero 제거)
- `MapHelper.GetType()` → `GetArrayType()` 리네임
