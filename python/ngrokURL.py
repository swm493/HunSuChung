import requests
import time
import json

def get_ngrok_url(output_file="HunSuChung/Assets/StreamingAssets/ngrok_url.txt"):
    while True:
        try:
            r = requests.get("http://127.0.0.1:4040/api/tunnels")
            data = r.json()
            public_url = data['tunnels'][0]['public_url']
            with open(output_file, "w") as f:
                f.write(public_url)
            print("✅ ngrok URL 저장됨:", public_url)
            break
        except Exception as e:
            print("ngrok 주소 대기 중...")
            time.sleep(1)

get_ngrok_url()

