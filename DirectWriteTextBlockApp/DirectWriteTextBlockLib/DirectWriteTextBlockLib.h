// DirectWriteTextBlockLib.h

#pragma once

#include <string>
#include <Dwrite.h>

using namespace System;

namespace DirectWriteTextBlockLibNS {

	public ref class DirectWriteTextBlockLib
	{
	public:
		DirectWriteTextBlockLib();
		~DirectWriteTextBlockLib();

		void setText(System::String^ text);
		void setFontFamilyName(System::String^ fontFamilyName);
		void setFontSize(float size);
		void setFontWeight(System::Windows::FontWeight fontWeight);

	private:
		std::wstring* _text;
		std::wstring* _fontFamilyName;
		float _fontSize;
		DWRITE_FONT_WEIGHT _fontWeight;
	};
}
