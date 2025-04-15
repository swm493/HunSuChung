environment.yml - 환경

수동 설치
conda python 3.10 환경
pip 24.0 버전
cuda 버전 맞게 잘. 여기서는 11.8임

pip install rvc-python
pip install torch==2.1.1+cu118 torchaudio==2.1.1+cu118 --index-url https://download.pytorch.org/whl/cu118
pip instal edge_tts

실행 방법

ngrok.exe 실행
ngrokURL.py 실행
server.py 실행