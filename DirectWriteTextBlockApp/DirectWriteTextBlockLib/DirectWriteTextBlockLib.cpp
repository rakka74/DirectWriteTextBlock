// これは メイン DLL ファイルです。

#include "stdafx.h"

#include "DirectWriteTextBlockLib.h"

using namespace DirectWriteTextBlockLibNS;

DirectWriteTextBlockLib::DirectWriteTextBlockLib()
{
	_text = new std::wstring(L"");
	_fontFamilyName = new std::wstring(L"arial");
	_fontSize = 12;
	_fontWeight = DWRITE_FONT_WEIGHT_REGULAR;

}

DirectWriteTextBlockLib::~DirectWriteTextBlockLib()
{
	delete _text;
	delete _fontFamilyName;
}

void MarshalString(String^ s, std::wstring& os) {
	using namespace Runtime::InteropServices;
	const wchar_t* chars =
		(const wchar_t*)(Marshal::StringToHGlobalUni(s)).ToPointer();
	os = chars;
	Marshal::FreeHGlobal(IntPtr((void*)chars));
}

void DirectWriteTextBlockLib::setText(System::String^ text)
{
	if (NULL != _text) {
		delete _text;
	}
	_text = new std::wstring();
	MarshalString(text, *_text);
}

void DirectWriteTextBlockLib::setFontFamilyName(System::String^ fontFamilyName)
{
	if (NULL != _fontFamilyName) {
		delete _fontFamilyName;
	}
	_fontFamilyName = new std::wstring();
	MarshalString(fontFamilyName, *_fontFamilyName);
}

void DirectWriteTextBlockLib::setFontSize(float fontSize)
{
	_fontSize = fontSize;
}

void DirectWriteTextBlockLib::setFontWeight(System::Windows::FontWeight fontWeight)
{
	// TODO
	_fontWeight = DWRITE_FONT_WEIGHT_REGULAR;
}