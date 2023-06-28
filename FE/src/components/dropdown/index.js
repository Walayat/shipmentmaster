import React from 'react';
import { Dropdown } from 'react-bootstrap';

const DropdownComponent = ({ category, setCategory }) => {

    const handleCategoryChange = (selectedCategory) => {
        setCategory(selectedCategory);

    };

    return (
        <Dropdown>
            <Dropdown.Toggle variant="primary" id="dropdown-basic">
                Select quote category
            </Dropdown.Toggle>
            <Dropdown.Menu>
                <Dropdown.Item onClick={() => handleCategoryChange('short')}>Short</Dropdown.Item>
                <Dropdown.Item onClick={() => handleCategoryChange('medium')}>Medium</Dropdown.Item>
                <Dropdown.Item onClick={() => handleCategoryChange('long')}>Long</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    );
};

export default DropdownComponent;
