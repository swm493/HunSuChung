import torch
from rvc_python.infer import RVCInference
import edge_tts
import asyncio

TEXT = "그거그렇게하는거아닌데에"
VOICE = "ko-KR-SunHiNeural"  # 여성 화자
OUTPUT = "output.wav"        # 저장 파일

async def create_tts(text=TEXT):
    communicate = edge_tts.Communicate(
        text=text,
        voice=VOICE,
        #style=STYLE,          # 생략 가능
        rate="+30%",           # 속도 (예: +10%, -20%)
        #pitch="+0%"           # 음조 (예: +5%, -5%)
    )
    await communicate.save(OUTPUT)

def generate_tts(text):
    asyncio.run(create_tts(text))

device="cuda" if torch.cuda.is_available() else "cpu"
# 🎯 전체 파이프라인 실행
def run_voice_assistant():

    # output.wav → Hubert feature 추출
    rvc_modelname = "ikuyo_kita"
    rvc_modelpath = "models/" + rvc_modelname + "/" + rvc_modelname
    rvc = RVCInference(device=device)
    rvc.set_params(f0up_key=7, protect=0.5)
    rvc.load_model(rvc_modelpath + ".pth", index_path=rvc_modelpath + ".index")  # 🟡 여기 실제 모델 경로 넣기
    rvc.infer_file("output.wav", "final_output.wav")  # RVC 변환 완료


if __name__ == "__main__":
    run_voice_assistant()