프로그램 이름: TagModbus

Modbus Map
* Register 정보에는 레지스터(16ibt)가 어떻게 해석되어야하는지 알 수 있도록 Data Type과 Scale Factor 정보가 있고, 이 레지스터의 값을 저장할 Tag 이름이 정의되어 있다.
* Modbus Map은 xml로 정의되어 있는데, yaml로 포맷 변경 검토

FormClient 화면
1. 통신 설정
* Modbus TCP/RTU 프로토콜 지원
* 프로토콜에 따라 셋업할 내용이 다르므로 팝업창으로 설정
  - TCP: IP, Port#, Connection Timeout
  - RTU: Port Name, Baud Rate, Data Bits, Parity, Stop Bits, Flow Control
* 추가 설정: Unit(Slave) Id, Response Timeout
* 변경된 설정값은 저장해서 다음 실행 때 초기값으로 사용

2. Modbus 명령 전송
* Register Type
  - Binary(Discrete Input, Coil)
  - Analog(Input, Holding Register)
* Address
  - Base Address
  - Start Address
  - Quantity
* Multiple Write: Single Access를 반복할지, Multiple Access를 한번에 처리할지 선택
  - Single: 변경된 레지스터에 대해 단일레지스터 쓰기 명령을 반복해서 전송
  - Multiple: 값이 변경된 레지스터의 첫번째 주소부터 마지막 주소를 모두 전송(범위에 있는 레지스터는 값 변경이 없더라도 전송됨)
  - Mixed: 값이 변경된 레지스터가 연속된 주소에 있는 경우 레지스터들을 묶어서 Multiple 전송(불필요한 전송 없음)

3. 조회결과 표시
* 표시 옵션: Search, Map Binding, Display Hex/Integer, Monitoring, Monitoring Interval
  - Map Binding: maps/ 폴더 아래의 yaml 파일들을 목록으로 표시
  - Monitoring: Read 명령을 주기적으로 전송함
    - Monitoring Option: 현재(기본값), 전체(Modbus Map의 CycleTime 기준으로 전체 조회)
    - Request Delay: 응답을 수신한 후에 다음 요청을 보내기까지 대기 시간
  - Monitoring Interval: Read 명령 전송 주기

* 표시 내용(기본): Address, Raw Value
  - row header: start addres를 기준으로 표시
  - address: base address를 더한 실제 레지스터 address를 표시
  - value(Raw): 16bit register raw value, [Write] 명령을 위해 입력 가능
* Modbus Map에 바인딩되어 있으면 다음 정보를 표시함
  - Converted, DataType, Format, Scale, Tag, Description
    - Converted: map에 의해 변환된 실제(원본) 값
    - DataType: value를 어떻게 해석할지 결정하는 원본 값의 data type
    - Format: float 처럼 여러개의 register를 묶어서 해석해야 하는 경우 merge 순서를 결정
    - Scale: 원본값이 소수점을 가질 때 수신한 value에 scale을 나눠서 원본값을 얻음
    - Tag: Dictionary에서 관리되는 Register 주소별로 붙여진 이름
    - Description; 레지스터에 대한 설명
  - Modbus Map 편집모드 지원
    - Map Binding 상태가 아닐 때: DataType, Scale, Tag, Description 입력하고 Modbus Map으로 저장하는 기능 
    - Map Binding 상태일 때: 입력/수정한 정보를 Binding된 Modbus Map에 업데이트

Tag Table
* Modbus Client는 조회한 값을 Tag에 저장하고, Tag는 Dictionary(또는 DataTable)에서 관리된다.
* Dictionary의 Tag 값은 FormTags 같은 다른 화면에서 접근할 수 있다.

FormTags 화면
* FormTags 화면이 추가되고 여기에는 Tag 이름, Tag 값, Tag 설명 컬럼이 있다.
* FormClient 화면의 우측에 Docking되는 Form으로 구현된다.
* FormTags 화면에서 tag를 검색할 수 있다.
* FormTags 화면에서 tag의 값을 변경할 수 있다. 값이 변경되는 경우 Modbus 쓰기 명령을 통해 장치(Modbus Server 또는 Slave)에 전송된다.