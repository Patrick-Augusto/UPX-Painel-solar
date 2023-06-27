# Documentação da API do Calculador Solar

A API do Calculador Solar é um serviço que fornece funcionalidades para calcular a geração de energia solar e dimensionar sistemas solares. Essa documentação descreve os endpoints disponíveis, os parâmetros de entrada e os modelos de dados utilizados.

## Endpoints

### Calcular Geração de Energia

Endpoint: `GET /generation/{city}/{energyType}`

Este endpoint calcula a geração de energia solar com base na cidade e tipo de energia especificados, juntamente com o consumo mensal informado.

#### Parâmetros de URL

- `city` (string): O nome da cidade para a qual se deseja calcular a geração de energia solar.
- `energyType` (string): O tipo de energia desejado (monofásico, bifásico ou trifásico).

#### Parâmetros de Consulta

- `monthlyConsumptions` (Lista de números): Uma lista contendo o consumo mensal de energia elétrica.

#### Resposta

A resposta será uma lista contendo a geração de energia solar para cada mês, com base no consumo informado.

### Calcular Sistema Solar

Endpoint: `GET /system/{moduleModel}/{inverterModel}`

Este endpoint calcula o dimensionamento de um sistema solar com base no modelo do módulo e do inversor especificados.

#### Parâmetros de URL

- `moduleModel` (string): O modelo do módulo desejado.
- `inverterModel` (string): O modelo do inversor desejado.

#### Resposta

A resposta será um objeto JSON contendo os seguintes campos:

- `ModuleModel` (string): O modelo do módulo utilizado no sistema.
- `NumModules` (inteiro): O número de módulos necessários no sistema.
- `InverterModel` (string): O modelo do inversor utilizado no sistema.
- `NumInverters` (inteiro): O número de inversores necessários no sistema.
- `TotalPower` (double): A potência total do sistema solar.

## Modelos de Dados

### Módulo

O modelo do módulo contém os seguintes campos:

- `Model` (string): O modelo do módulo.
- `Pmax` (double): A potência máxima do módulo.
- `Vmp` (double): A tensão no ponto de máxima potência.
- `Imp` (double): A corrente no ponto de máxima potência.
- `Voc` (double): A tensão de circuito aberto.
- `Isc` (double): A corrente de curto-circuito.
- `Efi` (double): A eficiência do módulo.
- `If_max` (double): A corrente máxima permitida no módulo.
- `Coef_Pmax` (double): O coeficiente para a potência máxima.
- `Coef_Voc` (double): O coeficiente para a tensão de circuito aberto.
- `Coef_Isc` (double): O coeficiente para a corrente de curto-circuito.

### Inversor

O modelo do inversor contém os seguintes campos:

- `Model` (string): O modelo do inversor.
- `In_Pmax` (inteiro): A potência máxima de entrada do inversor.
- `In_Vmin` (inteiro): A tensão mínima de entrada do inversor.
- `In_Vmax` (inteiro): A tensão má

xima de entrada do inversor.
- `Mppt` (inteiro): O número de pontos de máxima potência (MPPT) do inversor.
- `Pmax_Mppt` (inteiro): A potência máxima por MPPT.
- `Vmin_Mppt` (inteiro): A tensão mínima por MPPT.
- `Vmax_Mppt` (inteiro): A tensão máxima por MPPT.
- `In_Imax` (double): A corrente máxima de entrada do inversor.
- `In_Isc` (double): A corrente de curto-circuito de entrada do inversor.
- `Out_Pnom` (inteiro): A potência nominal de saída do inversor.
- `Out_Pmax` (inteiro): A potência máxima de saída do inversor.
- `Out_Vnom` (inteiro): A tensão nominal de saída do inversor.
- `Out_Vmax` (inteiro): A tensão máxima de saída do inversor.
- `Out_Imax` (double): A corrente máxima de saída do inversor.

## Banco de Dados SQL Server

A API utiliza um banco de dados SQL Server para armazenar os dados dos módulos e inversores. As tabelas utilizadas são:

### Tabela `Module`

Campos da tabela `Module`:

- `ID` (inteiro): Identificador único do módulo.
- `Model` (string): O modelo do módulo.
- `Pmax` (double): A potência máxima do módulo.
- `Vmp` (double): A tensão no ponto de máxima potência.
- `Imp` (double): A corrente no ponto de máxima potência.
- `Voc` (double): A tensão de circuito aberto.
- `Isc` (double): A corrente de curto-circuito.
- `Efi` (double): A eficiência do módulo.
- `If_max` (double): A corrente máxima permitida no módulo.
- `Coef_Pmax` (double): O coeficiente para a potência máxima.
- `Coef_Voc` (double): O coeficiente para a tensão de circuito aberto.
- `Coef_Isc` (double): O coeficiente para a corrente de curto-circuito.

### Tabela `Inverter`

Campos da tabela `Inverter`:

- `ID` (inteiro): Identificador único do inversor.
- `Model` (string): O modelo do inversor.
- `In_Pmax` (inteiro): A potência máxima de entrada do inversor.
- `In_Vmin` (inteiro): A tensão mínima de entrada do inversor.
- `In_Vmax` (inteiro): A tensão máxima de entrada do inversor.
- `Mppt` (inteiro): O número de pontos de máxima potência (MPPT) do inversor.
- `Pmax_Mppt` (inteiro): A potência máxima por MPPT.
- `Vmin_Mppt` (inteiro): A tensão mínima por MPPT.
- `Vmax_Mppt` (inteiro): A tensão máxima por MPPT.
- `In_Imax` (double): A corrente máxima de entrada do inversor.
- `In_Isc` (double): A corrente de curto-circuito de entrada do inversor.
- `Out_Pnom` (inte

iro): A potência nominal de saída do inversor.
- `Out_Pmax` (inteiro): A potência máxima de saída do inversor.
- `Out_Vnom` (inteiro): A tensão nominal de saída do inversor.
- `Out_Vmax` (inteiro): A tensão máxima de saída do inversor.
- `Out_Imax` (double): A corrente máxima de saída do inversor.



Tabela Module:

+----+-------+------+------+------+------+------+------+----------+----------+----------+----------+
| ID | Model | Pmax | Vmp  | Imp  | Voc  | Isc  | Efi  | If_max   | Coef_Pmax| Coef_Voc | Coef_Isc |
+----+-------+------+------+------+------+------+------+----------+----------+----------+----------+
| 1  | ...   | ...  | ...  | ...  | ...  | ...  | ...  | ...      | ...      | ...      | ...      |
| 2  | ...   | ...  | ...  | ...  | ...  | ...  | ...  | ...      | ...      | ...      | ...      |
| 3  | ...   | ...  | ...  | ...  | ...  | ...  | ...  | ...      | ...      | ...      | ...      |
+----+-------+------+------+------+------+------+------+----------+----------+----------+----------+


Tabela Inverter:

+----+-------+----------+----------+----------+------+------+----------+----------+-----------+-----------+-----------+-----------+-----------+-
| ID | Model | In_Pmax  | In_Vmin  | In_Vmax  | Mppt | Pmax_Mppt| Vmin_Mppt | Vmax_Mppt | In_Imax   | In_Isc    | Out_Pnom  | Out_Pmax  | Out_Vnom  | Out_Vmax  | Out_Imax  |
+----+-------+----------+----------+----------+------+------+----------+----------+-----------+-----------+-----------+-----------+-----------+-
| 1  | ...   | ...      | ...      | ...      | ...  | ...      | ...      | ...      | ...       | ...       | ...       | ...       | ...       | ...       | ...       |
| 2  | ...   | ...      | ...      | ...      | ...  | ...      | ...      | ...      | ...       | ...       | ...       | ...       | ...       | ...       | ...       |
| 3  | ...   | ...      | ...      | ...      | ...  | ...      | ...      | ...      | ...       | ...       | ...       | ...       | ...       | ...       | ...       |
+----+-------+----------+----------+----------+------+------+----------+----------+-----------+-----------+-----------+-----------+-----------+-
