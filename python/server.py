from flask import Flask, request, send_file
import VoicePipeline
import os

app = Flask(__name__)

@app.route("/get-audio", methods=["GET"])
def get_audio():
    VoicePipeline.run_voice_assistant()
    file_path = "final_output.wav"  # 서버에 저장된 음성 파일 경로
    if not os.path.exists(file_path):
        return "File not found", 404
    return send_file(file_path, mimetype="audio/wav", as_attachment=True)

@app.route("/speak", methods=["POST"])
def speak():
    text = request.form.get("text")
    print("🔊 받은 텍스트:", text)

    if not text:
        return "No text provided", 400

    try:
        VoicePipeline.generate_tts(text)
        return "TTS Success", 200
    except Exception as e:
        print("❌ TTS 변환 실패:", e)
        return "Internal Server Error", 500


if __name__ == "__main__":
    from waitress import serve
    serve(app, host="0.0.0.0", port=5000)